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
        public static List<Cliente> getCustomers()
        {
            return null;
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