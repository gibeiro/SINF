using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Data.SQLite;

namespace FirstREST.Database
{
    public class SqliteDB
    {
        public static SQLiteConnection conn;
        public static SQLiteCommand com;

        /* MapPath(PATH) returns the physical address maped to the virtual address PATH */
        public static readonly string DB_PATH = HttpContext.Current.Server.MapPath("Database/db.sqlite");
        public static readonly string DB_SCRIPT_PATH = HttpContext.Current.Server.MapPath("Database/db.sql");

        /* creates db (if it doesn't exist) and connects to it */
        public static void init(bool overwrite = false)
        {
            /* creates db file */
            if (!File.Exists(DB_PATH))
            {
                SQLiteConnection.CreateFile(DB_PATH);
                overwrite = true;
            }

            /* connects to db */
            conn = new SQLiteConnection("Data Source=" + DB_PATH + ";Version=3;foreign keys=true;");
            conn.Open();

            /* prepares sqlite command */
            com = new SQLiteCommand(conn);

            if (overwrite)
            {
                /* reads sql script from file */
                com.CommandText = File.ReadAllText(DB_SCRIPT_PATH);

                /* executes sql script */
                try { com.ExecuteNonQuery(); }
                catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

                parseSaft("Database/SAFT_DEMOSINF.xml");
                parsePrimavera();
            }
        }

        /* loads data from saft into db */
        public static void parseSaft(string path)
        {
            
            /* creates deserializer and starts parsing xml into object */
            XmlSerializer serializer = new XmlSerializer(typeof(AuditFile));

            /* reads xml into buffer */
            string xml = File.ReadAllText(HttpContext.Current.Server.MapPath(path));
            byte[] buffer = Encoding.UTF8.GetBytes(xml);

            /* deletes current records */
            com.CommandText =
                @"pragma foreign_keys = off;
                delete from customer;
                delete from product;
                delete from invoice;
                delete from line;
                delete from purchase;
                pragma foreign_keys = on;";
            com.ExecuteNonQuery();

            using (MemoryStream stream = new MemoryStream(buffer))
            {
                /* deserialize xml into an object */
                AuditFile saft = (AuditFile)serializer.Deserialize(stream);

                /* add customers, products and invoices to db */
                foreach (Product p in saft.MasterFiles.Product) p.insertIntoDB(conn);
                foreach (Customer c in saft.MasterFiles.Customer) c.insertIntoDB(conn);
                foreach (Invoice i in saft.SourceDocuments.SalesInvoices.Invoice)
                {
                    i.insertIntoDB(conn);
                    /* add lines from each invoice to db */
                    foreach (Line l in i.Line) l.insertIntoDB(i.InvoiceNo, conn);
                }
            }
        }

        public static void parsePrimavera(){
           Lib_Primavera.PriIntegration.listProductsInv();
           Lib_Primavera.PriIntegration.listPurchases();
        }
    }
}