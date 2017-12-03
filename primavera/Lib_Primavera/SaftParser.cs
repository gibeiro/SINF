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
using Saft;

namespace FirstREST.Lib_Primavera
{
    public class SaftParser
    {
        private static XmlNode root;
        private static XmlNamespaceManager nsmgr;
        private static XmlSerializer serializer;
		private static SQLiteConnection conn;
		private const string DB_PATH = "db/db.sqlite";
		private const string DB_SCRIPT_PATH = "db/db.sql";

		// nada deste codigo foi testado lmao
		public static void parseSAFT(string path) {
			/* creates db */
			SQLiteConnection.CreateFile(DB_PATH);

			/* connects to db */
			conn = new SQLiteConnection("Data Source=" + DB_PATH + ";Version=3;");
			conn.Open();

			/* reads sql script from file */
			string script = File.ReadAllText(DB_SCRIPT_PATH);

			/* runs sql script (creates all the tables on new db) */
			SQLiteCommand com = new SQLiteCommand(script,conn);
			com.ExecuteNonQuery();		

			/* creates deserializer and starts parsing xml into object */
			serializer = new XmlSerializer(typeof(AuditFile));

			/* reads xml into buffer */
			string xml = File.ReadAllText(path);
			var buffer = Encoding.UTF8.GetBytes(xml);
			using (var stream = new MemoryStream(buffer))
			{
				var saft = (AuditFile)serializer.Deserialize(stream);
				/* TODO deserializar saft em objectos,
				 * pegar nos objectos e introduzir info nas devidas tabelas
				 * https://dennymichael.net/2014/05/30/convert-xml-to-csharp-classes/comment-page-1/
				 */				 
			}

		}

        public static void loadSAFT(string path)
        {
            XmlDocument saft = new XmlDocument();
            saft.Load(path);
            root = saft.DocumentElement;
            nsmgr = new XmlNamespaceManager(saft.NameTable);
            serializer = new XmlSerializer(typeof(String));
            nsmgr.AddNamespace("a", "urn:OECD:StandardAuditFile-Tax:PT_1.01_01");
            nsmgr.AddNamespace("doc", "urn:schemas-basda-org:schema-extensions:documentation");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgr.AddNamespace("schemaLocation", "urn:OECD:StandardAuditFile-Tax:PT_1.01_01 ../schemas/SAF-T.xsd");
        }

        public static List<Model.Cliente> getClientes()
        {
            List<Model.Cliente> ret = new List<Model.Cliente>();
            XmlNodeList clientes = root.SelectNodes("//a:MasterFiles/a:Customer",nsmgr);
            foreach (XmlNode cliente in clientes)
            {
                ret.Add(new Model.Cliente
                {
                    CodCliente = cliente.SelectSingleNode("a:CustomerID",nsmgr).InnerText,
                    NomeCliente = cliente.SelectSingleNode("a:CompanyName", nsmgr).InnerText,
                    NumContribuinte = cliente.SelectSingleNode("a:CustomerTaxID", nsmgr).InnerText,
                    Morada = cliente.SelectSingleNode("a:BillingAddress/a:AddressDetail", nsmgr).InnerText
                });
            }
            return ret;
        }
        

    }
}