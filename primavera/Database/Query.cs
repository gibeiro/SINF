using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using FirstREST.Lib_Primavera;
using Newtonsoft.Json;


namespace FirstREST.Database
{
    public class Query
    {
        private static SQLiteDataReader reader;

        /* done */
        #region overview
        public static List<object> overviewGrowth(string from, string to){
            List<object> growth = new List<object>();
            SqliteDB.com.CommandText =
                @"select nettotal, cast(julianday(date) - julianday(@1) as integer) as day, date
                from invoice
                where date between @1 and @2
                group by day
                order by day asc ";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }            

            while (reader.Read()) 
                growth.Add(new {
                    netsale = reader["nettotal"],
                    day = reader["day"],
                    date = reader["date"]
                });
            reader.Close();

            /*SqliteDB.com.CommandText =
                @"select ammount*unitprice as nettotal, cast(julianday(date) - julianday(@1) as integer) as day, date
                from purchase
                where date between @1 and @2 and type = 'VFA' 
                group by day
                order by day asc ";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                growth.Add(new
                {
                    spent = reader["nettotal"],
                    day = reader["day"],
                    date = reader["date"]
                });
            reader.Close();*/
            
            return growth;
        }
        public static List<object> overviewClients(int limit){
            List<object> clients = new List<object>();

            SqliteDB.com.CommandText =
                @"select companyname, gross
                from customer join (
                select customerid, sum(grosstotal) as gross
                from invoice
                group by customerid
                ) on id = customerid
                order by gross desc
                limit @1";
            SqliteDB.com.Parameters.AddWithValue("@1",limit);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                clients.Add(new {
                    name = reader["companyname"],
                    gross = reader["gross"]
                });
            reader.Close();           

            return clients;
        }
        public static List<object> overviewProducts(int limit)
        {
            List<object> products = new List<object>();

            SqliteDB.com.CommandText =
                @"select productcode, quantity*unitprice as gross
                from line
                group by productcode
                order by gross desc
                limit @1";
            SqliteDB.com.Parameters.AddWithValue("@1", limit);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }          

            while (reader.Read())
            {
                products.Add(new {
                    name = reader["productcode"],
                    gross = reader["gross"]
                });
            } reader.Close(); 

            return products;
        }
        public static object overviewRevenue(int year) {            
            SqliteDB.com.CommandText =
               @"select sum(grosstotal) as gross,
               strftime('%Y',date) as year
               from invoice
               where year <= @1
               group by year
               order by year desc
               limit 2";
            SqliteDB.com.Parameters.AddWithValue("@1", year.ToString());

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            dynamic revenue = new ExpandoObject();
            reader.Read();
            revenue.current = reader["gross"];
            reader.Read();
            revenue.previous = reader["gross"];
            reader.Close();

            return revenue;
        }
        #endregion overview

        /* done */
        #region product
        public static List<object> productVolume(string id, string from, string to)
        {
            List<object> volume = new List<object>();
            SqliteDB.com.CommandText =
                @"select sum(unitprice*quantity) as gross, date,
                cast(julianday(date) - julianday(@1) as integer) as day
                from line join invoice on invoice.number = invoicenumber
                where date between @1 and @2
                and productcode = @3
                group by day
                order by day asc";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);
            SqliteDB.com.Parameters.AddWithValue("@3", id);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                volume.Add(new
                {
                    gross = reader["gross"],
                    day = reader["day"],
                    date = reader["date"]
                });
            reader.Close();

            return volume;
        }
        public static List<object> productSales(string id, string from, string to)
        {
            List<object> volume = new List<object>();
            SqliteDB.com.CommandText =
                @"select count(*) as sales, date,
                cast(julianday(date) - julianday(@1) as integer) as day
                from line join invoice on invoice.number = invoicenumber
                where date between @1 and @2
                and productcode = @3
                group by day
                order by day asc";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);
            SqliteDB.com.Parameters.AddWithValue("@3", id);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                volume.Add(new
                {
                    sales = reader["sales"],
                    day = reader["day"],
                    date = reader["date"]
                });
            reader.Close();

            return volume;
        }
        public static List<object> productPrice(string id, string from, string to)
        {
            List<object> volume = new List<object>();
            SqliteDB.com.CommandText =
                @"select unitprice, date,
                cast(julianday(date) - julianday(@1) as integer) as day
                from line join invoice on invoice.number = invoicenumber
                where date between @1 and @2
                and productcode = @3
                group by day
                order by day asc";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);
            SqliteDB.com.Parameters.AddWithValue("@3", id);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                volume.Add(new
                {
                    price = reader["unitprice"],
                    day = reader["day"],
                    date = reader["date"],
                });
            reader.Close();

            return volume;
        }
        public static object productInfo(string id)
        {
            dynamic info = new ExpandoObject(); ;
            SqliteDB.com.CommandText =
                @"select * from product where code = @1";
            SqliteDB.com.Parameters.AddWithValue("@1", id);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            reader.Read();
            info.type = reader["type"];
            info.id = reader["code"];
            info.group = reader["productgroup"];
            info.description = reader["description"];
            info.code = reader["numbercode"];
            info.stk = reader["stock"];
            info.pcm = reader["pcm"];
            info.pvp = reader["pvp"];
            reader.Close();

            return info;
        }
        #endregion product

        /* done */
        #region customer
        public static object customerInfo(string id)
        {
            List<object> volume = new List<object>();
            SqliteDB.com.CommandText = "select * from customer where id = @1";
            SqliteDB.com.Parameters.AddWithValue("@1", id);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            dynamic customer = new ExpandoObject();
            reader.Read();
            customer.id = reader["id"];
            customer.account = reader["accountid"];
            customer.taxid = reader["customertaxid"];
            customer.name = reader["companyname"];
            customer.address = reader["address"];
            customer.city = reader["city"];
            customer.postalcode = reader["postalcode"];
            customer.country = reader["country"];
            customer.telephone = reader["telephone"];
            customer.fax = reader["fax"];
            customer.website = reader["website"];
            reader.Close();

            return customer;
        }
        public static List<object> customerVolume(string id, string from, string to)
        {
            List<object> volume = new List<object>();
            SqliteDB.com.CommandText =
                @"select grosstotal, date,
                cast(julianday(date) - julianday(@1) as integer) as day
                from customer join invoice on id = customerid
                where customerid = @3
                and date between @1 and @2
                group by day
                order by day asc";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);
            SqliteDB.com.Parameters.AddWithValue("@3", id);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                volume.Add(new
                {
                    gross = reader["grosstotal"],
                    day = reader["day"],
                    date = reader["date"]
                });
            reader.Close();

            return volume;
        }
        public static List<object> customerSales(string id, string from, string to)
        {
            List<object> volume = new List<object>();
            SqliteDB.com.CommandText =
                @"select count(*) as sales, date,
                cast(julianday(date) - julianday(@1) as integer) as day
                from customer join invoice on id = customerid
                where customerid = @3
                and date between @1 and @2
                group by day
                order by day asc";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);
            SqliteDB.com.Parameters.AddWithValue("@3", id);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                volume.Add(new
                {
                    sales = reader["sales"],
                    day = reader["day"],
                    date = reader["date"]
                });
            reader.Close();

            return volume;
        }
        public static List<object> customerProducts(string id, int limit)
        {
            List<object> products = new List<object>();
            SqliteDB.com.CommandText =
                @"select sum(unitprice*quantity) as gross, productcode
                from line join invoice on invoice.number = invoicenumber
                where customerid = @1
                group by productcode
                order by gross desc
                limit @2";
            SqliteDB.com.Parameters.AddWithValue("@1", id);
            SqliteDB.com.Parameters.AddWithValue("@2", limit);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                products.Add(new
                {
                    gross = reader["gross"],
                    product = reader["productcode"]
                });
            reader.Close();

            return products;
        }
        #endregion customer

        /* done */
        #region sales
        public static List<object> salesVolume(string from, string to)
        {
            List<object> volume = new List<object>();

            SqliteDB.com.CommandText =
                @"select count(*) as sales,
                cast(julianday(date) - julianday(@1) as integer) as day
                from invoice
                where date between @2 and @3
                group by day
                order by day asc";

            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                volume.Add(new {
                    sales = reader["sales"],
                    day = reader["day"],
                    date = reader["date"]
                });
            reader.Close();

            return volume;
        }
        public static List<object> salesRevenue(string from, string to)
        {
            List<object> revenue = new List<object>();

            SqliteDB.com.CommandText =
                @"select sum(grosstotal) as gross, date,
                cast(julianday(date) - julianday(@1) as integer) as day
                from invoice
                where date between @2 and @3
                group by day
                order by day asc";

            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                revenue.Add(new
                {
                    gross = reader["gross"],
                    day = reader["day"],
                    date = reader["date"]
                });
            reader.Close();

            return revenue;
        }
        public static List<object> salesLatest(int limit)
        {
            List<object> sales = new List<object>();

            SqliteDB.com.CommandText =
                @"select customerid, type, grosstotal, date, status 
                from invoice order by date desc limit @1";
            SqliteDB.com.Parameters.AddWithValue("@1", limit);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                sales.Add(new
                {
                    customer = reader["customerid"],
                    type = reader["type"],
                    gross = reader["grosstotal"],
                    date = reader["date"],
                    status = reader["status"]
                });
            reader.Close();

            return sales;
        }
        #endregion sales

        /* todo - requires pri_integration queries*/
        #region purchases
        public static List<object> purchasesExpenditure(string from, string to){
            List<object> volume = new List<object>();
            SqliteDB.com.CommandText =
                @"select sum(unitprice*ammount) as cost, date,
                cast(julianday(date) - julianday(@1) as integer) as day
                from purchase
                where date between @1 and @2
                group by day
                order by day asc";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                volume.Add(new {
                    cost = reader["cost"],
                    date = reader["date"],
                    day = reader["day"]
                });
            reader.Close();

            return volume;
        }
        public static List<object> purchasesVolume(string from, string to)
        {
            List<object> volume = new List<object>();
            SqliteDB.com.CommandText =
                @"select count(*) as purchases, date,
                cast(julianday(date) - julianday(@1) as integer) as day
                from purchase
                where date between @1 and @2
                group by day
                order by day asc";
            SqliteDB.com.Parameters.AddWithValue("@1", from);
            SqliteDB.com.Parameters.AddWithValue("@2", to);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                volume.Add(new
                {
                    purchases = reader["purchases"],
                    date = reader["date"],
                    day = reader["day"]
                });
            reader.Close();

            return volume;
        }
        public static List<object> purchasesLatest(int limit){
            List<object> purchases = new List<object>();
            SqliteDB.com.CommandText =
                @"select unitprice*ammount as cost, ammount, code, description
                from purchase join product
                on productcode = code
                order by date desc 
                limit @1";
            SqliteDB.com.Parameters.AddWithValue("@1", limit);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                purchases.Add(new {
                    totalcost = reader["cost"],
                    quantity = reader["ammount"],
                    productname = reader["description"],
                    productcode = reader["code"],
                });
            reader.Close();

            return purchases;
        }
        #endregion purchases

        /* todo - requires pri_integration queries*/
        #region inventory

        public static List<object> inventoryProducts() {
            List<object> products = new List<object>();

            SqliteDB.com.CommandText =
                @"select a.code, description, productgroup,
                a.stock, ifnull(orders,0) as to_receive,
                a.stock + ifnull(orders,0) as total from 
                (select stock, code from product) as a 
                left join 
                (select sum(ammount) as orders, productcode 
                from purchase where type = 'ECF' group by productcode) as b 
                on a.code = b.productcode, product 
                where a.code = product.code";

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                products.Add(new
                {
                    to_receive = reader["to_receive"],
                    total = reader["total"],
                    stock = reader["a.stock"],
                    code = reader["a.code"],
                    name = reader["description"],
                    category = reader["productgroup"]
                });
            reader.Close();

            return products;
        }
        public static List<object> inventoryGroups() {
            List<object> groups = new List<object>();

            SqliteDB.com.CommandText =
                @"select productgroup,
                sum(a.stock + ifnull(b.orders,0)) as total from 
                (select stock, code from product) as a 
                left join 
                (select sum(ammount) as orders, productcode 
                from purchase where type = 'ECF' group by productcode) as b 
                on a.code = b.productcode, product 
                where a.code = product.code 
                group by product.productgroup 
                order by total desc";

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                groups.Add(new
                {
                    group = reader["productgroup"],
                    total = reader["total"]
                });
            reader.Close();

            return groups;
        }
        public static object inventoryInfo() {
            dynamic info = new ExpandoObject();

            SqliteDB.com.CommandText = @"select sum(stock) as in_hand from product";
            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            reader.Read();
            info.in_hand = reader["in_hand"];
            reader.Close();

            SqliteDB.com.CommandText =
                @"select sum(orders) as to_receive from 
                (select sum(ammount) as orders from purchase 
                where type = 'ECF' group by productcode)";
            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            reader.Read();
            info.to_receive = reader["to_receive"];
            reader.Close();

            return info;
        }

        public static List<object> inventoryLowStock(int limit = 10)
        {
            List<object> products = new List<object>();

            SqliteDB.com.CommandText =
                @"select a.code, description,
                a.stock, ifnull(orders,0) as to_receive,
                a.stock + ifnull(orders,0) as total from 
                (select stock, code from product) as a 
                left join 
                (select sum(ammount) as orders, productcode 
                from purchase where type = 'ECF' group by productcode) as b 
                on a.code = b.productcode, product 
                where a.code = product.code 
                and total is not null 
                order by total asc 
                limit @1";
            SqliteDB.com.Parameters.AddWithValue("@1", limit);

            try { reader = SqliteDB.com.ExecuteReader(); }
            catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }

            while (reader.Read())
                products.Add(new
                {
                    code = reader["a.code"],
                    name = reader["description"],
                    in_hand = reader["a.stock"],
                    to_receive = reader["to_receive"],
                    total = reader["total"]
                });
            reader.Close();

            return products;
        }
        #endregion
        
    }        
}