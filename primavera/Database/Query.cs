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
        public static List<Growth> growth(string from, string to)
        {
            List<Growth> growth = new List<Growth>();
            SqliteDB.com.CommandText =
                "select nettotal, cast(julianday(date) - julianday(@1) as integer) as day " +
                "from invoice "+
                "where date between @2 and @3 "+
                "group by day "+
                "order by day asc ";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", from);
            SqliteDB.com.Parameters.AddWithValue("@3", to);
            reader = SqliteDB.com.ExecuteReader();
            //try {  }
            //catch (SQLiteException e) { }

            while (reader.Read())
            {
                growth.Add(new Growth { 
                    Earn = Convert.ToDouble(reader["nettotal"]),
                    Day = Convert.ToInt32(reader["day"])
                });
            } reader.Close();           

            return growth;
        }
        public static List<TopClientes> topClients(int limit){
            List<TopClientes> clients = new List<TopClientes>();

            SqliteDB.com.CommandText =
                "select companyname, gross " +
                "from customer join (" +
                "select customerid, sum(grosstotal) as gross " +
                "from invoice " +
                "group by customerid" +
                ") on id = customerid " +
                "order by gross desc " +
                "limit @1";
            SqliteDB.com.Parameters.AddWithValue("@1",limit);
            reader = SqliteDB.com.ExecuteReader();
            //try {  }
            //catch (SQLiteException e) { }

            while (reader.Read())
            {
                clients.Add(new TopClientes
                {
                    CodCliente = Convert.ToString(reader["companyname"]),
                    Faturacao = Convert.ToDouble(reader["gross"])
                });
            } reader.Close();           

            return clients;
        }
        public static List<TopArtigos> topProducts(int limit)
        {
            List<TopArtigos> products = new List<TopArtigos>();

            SqliteDB.com.CommandText =
                "select productcode, quantity*unitprice as gross " +
                "from line " +
                "group by productcode " +
                "order by gross desc " +
                "limit @1";
            SqliteDB.com.Parameters.AddWithValue("@1", limit);
            reader = SqliteDB.com.ExecuteReader();
            //try {  }
            //catch (SQLiteException e) { }

            while (reader.Read())
            {
                products.Add(new TopArtigos
                {
                    CodArtigo = Convert.ToString(reader["productcode"]),
                    Faturacao = Convert.ToDouble(reader["gross"])
                });
            } reader.Close(); 

            return products;
        }
        public static Revenue revenue(int year) {
            Revenue revenue = new Revenue();
            SqliteDB.com.CommandText =
               "select sum(grosstotal) as gross," +
               "strftime('%Y',date) as year " +
               "from invoice " +
               "where year <= @1 " +
               "group by year " +
               "order by year desc " +
               "limit 2";
            SqliteDB.com.Parameters.AddWithValue("@1", year.ToString());
            reader = SqliteDB.com.ExecuteReader();
            //try { }
            //catch (SQLiteException e) { }

            reader.Read();
            revenue.Current = Convert.ToDouble(reader["gross"]);
            reader.Read();
            revenue.Previous = Convert.ToDouble(reader["gross"]);
            reader.Close(); 

            return revenue;
        }
        #endregion overview

        #region purchases
        #endregion purchases

        #region sales       
        public static List<SalesVolume> volume(string from, string to)
        {
            List<SalesVolume> volume = new List<SalesVolume>();

            SqliteDB.com.CommandText =
                "select count(*) as sales, sum(grosstotal) as profit," +
                "cast(julianday(date) - julianday(@1) as integer) as day " +
                "from invoice " +
                "where date between @2 and @3 " +
                "group by day " +
                "order by day asc";

            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", from);
            SqliteDB.com.Parameters.AddWithValue("@3", to);
            reader = SqliteDB.com.ExecuteReader();
            //try {  }
            //catch (SQLiteException e) { }

            while (reader.Read())
            {
                volume.Add(new SalesVolume
                {
                    Sales = Convert.ToInt32(reader["sales"]),
                    Profit = Convert.ToDouble(reader["profit"]),
                    Day = Convert.ToInt16(reader["day"])
                });
            } reader.Close();    

            return volume;
        }
        public static List<Sale> sales(int limit)
        {
            List<Sale> sales = new List<Sale>();

            SqliteDB.com.CommandText =
                "select customerid, type, grosstotal, date, status " +
                "from invoice order by date desc limit @1";
            SqliteDB.com.Parameters.AddWithValue("@1",limit);
            reader = SqliteDB.com.ExecuteReader();
            //try {  }
            //catch (SQLiteException e) { }

            while (reader.Read())
            {
                sales.Add(new Sale
                {
                    Customer = Convert.ToString(reader["customerid"]),
                    Type = Convert.ToString(reader["type"]),
                    Amount = Convert.ToDouble(reader["grosstotal"]),
                    Date = Convert.ToString(reader["date"]),
                    Delivered = Convert.ToString(reader["status"])
                });
            } reader.Close();  

            return sales;
        }
        #endregion sales
   
        public static Cliente getCustomer(string id)
        {
            SqliteDB.com.CommandText = "select * from customer where id = @1";
            SqliteDB.com.Parameters.AddWithValue("@1",id);
            reader = SqliteDB.com.ExecuteReader();
            reader.Read();
            Cliente cliente = new Cliente{ 
            CodCliente = (String)reader["id"],
            NomeCliente = (String)reader["companyname"],
            NumContribuinte = (String)reader["customertaxid"],
            Morada = (String)reader["address"],
            Email = (String)reader["email"]
            };
            reader.Close();
            return cliente;
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
            } reader.Close(); 
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