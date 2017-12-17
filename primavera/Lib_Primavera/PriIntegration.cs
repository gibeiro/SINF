using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interop.ErpBS900;
using Interop.StdPlatBS900;
using Interop.StdBE900;
using Interop.GcpBE900;
using ADODB;
using System.Data.SQLite;
using FirstREST.Database;

namespace FirstREST.Lib_Primavera
{
    public class PriIntegration
    {

        #region purchases

        public static void listPurchases()
        {
            Database.SqliteDB.com.CommandText = 
            @"pragma foreign_keys = off;
            insert into purchase values (@1,@2,@3,@4,@5,@6);
            pragma foreign_keys = on;";
            
            StdBELista objList;
            if (!PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim())) return;
            
            objList = PriEngine.Engine.Consulta(
                @"SELECT CabecCompras.Entidade,LinhasCompras.Artigo,LinhasCompras.PrecUnit,
                cast(LinhasCompras.Quantidade as integer) as Quantidade,CabecCompras.TipoDoc,CabecCompras.DataDoc
                FROM CabecCompras,LinhasCompras
                WHERE LinhasCompras.IdCabecCompras = CabecCompras.Id AND (CabecCompras.TipoDoc = 'VFA' OR CabecCompras.TipoDoc = 'ECF')"
            );
                 
            while (!objList.NoFim())
            {
                string entidade = objList.Valor("Entidade");
                string artigo = objList.Valor("Artigo");
                double precUnit = objList.Valor("PrecUnit");
                int quant = objList.Valor("Quantidade");
                string tipo = objList.Valor("TipoDoc");
                DateTime data = objList.Valor("DataDoc");
                Database.SqliteDB.com.Parameters.AddWithValue("@1", entidade);
                Database.SqliteDB.com.Parameters.AddWithValue("@2", precUnit);
                Database.SqliteDB.com.Parameters.AddWithValue("@3", quant);
                Database.SqliteDB.com.Parameters.AddWithValue("@4", tipo);
                Database.SqliteDB.com.Parameters.AddWithValue("@5", data.ToString("yyyy-MM-dd"));
                Database.SqliteDB.com.Parameters.AddWithValue("@6", artigo);
                Database.SqliteDB.com.ExecuteNonQuery();
                objList.Seguinte();

                
            }
        }

        #endregion purchases

        #region inventory

        public static void listProductsInv()
        {
            SqliteDB.com.CommandText = "update product set stock=@1,pcm=@2,pvp=@3 where code=@4";
            StdBELista objList;
            if (!PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim())) return;
            
            objList = PriEngine.Engine.Consulta(
                @"SELECT Artigo.Artigo,cast(Artigo.STKActual as integer) as STKActual,Artigo.PCMedio,ArtigoMoeda.PVP1
                FROM Artigo,ArtigoMoeda
                WHERE Artigo.Artigo = ArtigoMoeda.Artigo"
            );

            while (!objList.NoFim())
            {
                string artigo = objList.Valor("Artigo");
                int stkatual = objList.Valor("STKActual");
                double pcm = objList.Valor("PCMedio");
                double pvp = objList.Valor("PVP1");
                SqliteDB.com.Parameters.AddWithValue("@1",stkatual);
                SqliteDB.com.Parameters.AddWithValue("@2", pcm);
                SqliteDB.com.Parameters.AddWithValue("@3", pvp);
                SqliteDB.com.Parameters.AddWithValue("@4", artigo);
                SqliteDB.com.ExecuteNonQuery();
                objList.Seguinte();
            }
            
        }

        #endregion inventory
        
    }
}
