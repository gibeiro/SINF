using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using FirstREST.Lib_Primavera;
using FirstREST.Lib_Primavera.Model;
using FirstREST.Lib_Primavera.Model.Custom;


namespace FirstREST.Database
{
    public class Query
    {
        private static SQLiteDataReader reader;

        #region overview
        public static List<Growth> growth(string from = "2016-01-01", string to = "2017-01-01")
        {
            List<Growth> growth = new List<Growth>();
            SqliteDB.com.CommandText =
                "select nettotal, (julianday(date) - julianday(@1)) as day" +
                "from invoice"+
                "where date between @2 and @3"+
                "group by julianday(date)";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", from);
            SqliteDB.com.Parameters.AddWithValue("@3", to);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { }

            while (reader.Read())
            {
                growth.Add(new Growth { 
                    Earn = (double)reader["nettotal"],
                    Day = (double)reader["day"]
                });
            }            

            return growth;
        }
        public static List<TopClientes> topClients(int limit = 10){
            List<TopClientes> clients = new List<TopClientes>();

            SqliteDB.com.CommandText =
                "select companyname, gross" +
                "from customer join (" +
                "select customerid, sum(grosstotal) as gross" +
                "from invoice" +
                "group by customerid" +
                ") on id = customerid" +
                "order by gross desc" +
                "limit @1";
            SqliteDB.com.Parameters.AddWithValue("@1",limit);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { }

            while (reader.Read())
            {
                clients.Add(new TopClientes
                {
                    CodCliente = (string)reader["companyname"],
                    Faturacao = (double)reader["gross"]
                });
            }            

            return clients;
        }
        public static List<TopArtigos> topProducts(int limit = 10)
        {
            List<TopArtigos> products = new List<TopArtigos>();

            SqliteDB.com.CommandText =
                "select productcode, quantity*unitprice as gross" +
                "from line" +
                "group by productcode" +
                "order by gross desc" +
                "limit @1";
            SqliteDB.com.Parameters.AddWithValue("@1", limit);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { }

            while (reader.Read())
            {
                products.Add(new TopArtigos
                {
                    CodArtigo = (string)reader["productcode"],
                    Faturacao = (double)reader["gross"]
                });
            }  

            return products;
        }
        public static string revenue(int year = 2016) {
            string json = "{";
            SqliteDB.com.CommandText =
               "select sum(grosstotal) as gross," +
               "strftime('%Y',date) as year" +
               "from invoice" +
               "where year <= @1" +
               "group by year" +
               "order by year desc" +
               "limit 2";
            SqliteDB.com.Parameters.AddWithValue("@1", year.ToString());

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { }

            reader.Read();
            json += "\"current\":" + (string)reader["gross"] + ",";

            reader.Read();
            json += "\"previous\":" + (string)reader["gross"];

            return json + "}";
        }
        #endregion overview

        #region purchases
        #endregion purchases

        #region sales
        #endregion sales

        

        public static Cliente getCustomer(string id)
        {
            SqliteDB.com.CommandText = "select * from customer where id = @1";
            SqliteDB.com.Parameters.AddWithValue("@1",id);
            reader = SqliteDB.com.ExecuteReader();
            reader.Read();
            return new Cliente { 
            CodCliente = (String)reader["id"],
            NomeCliente = (String)reader["companyname"],
            NumContribuinte = (String)reader["customertaxid"],
            Morada = (String)reader["address"],
            Email = (String)reader["email"]
            };
        }
        public static List<Cliente> getCustomers(int limit = 10, int offset = 0)
        {
            List<Cliente> customers = new List<Cliente>();
            SqliteDB.com.CommandText = "select * from customer limit @1 offset @2";
            SqliteDB.com.Parameters.AddWithValue("@1", limit);
            SqliteDB.com.Parameters.AddWithValue("@1", offset);
            reader = SqliteDB.com.ExecuteReader();
            while (reader.Read())
            {
                customers.Add(new Cliente
                {
                    CodCliente = (String)reader["id"],
                    NomeCliente = (String)reader["companyname"],
                    NumContribuinte = (String)reader["customertaxid"],
                    Morada = (String)reader["address"],
                    Email = (String)reader["email"]
                });
            }
            return customers;
        }
        public static List<CabecDoc> getClientPurchases(string id)
        {
            return null;
        }
        public static List<TopArtigos> getClientTopProducts(string id, int n)
        {
            return null;
        }
    }
}