using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
namespace FirstREST.Lib_Primavera
{
    public class SaftParser
    {
        private static XmlNode root;
        private static XmlNamespaceManager nsmgr;
        private static XmlSerializer serializer;
        public static void loadSAFT(string path)
        {
            XmlDocument saft = new XmlDocument();
            saft.Load(path);
            root = saft.DocumentElement;
            nsmgr = new XmlNamespaceManager(saft.NameTable);
            serializer = new XmlSerializer(typeof(String));
            nsmgr.AddNamespace("a","urn:OECD:StandardAuditFile-Tax:PT_1.03_01");
            nsmgr.AddNamespace("doc", "urn:schemas-basda-org:schema-extensions:documentation");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgr.AddNamespace("schemaLocation", "urn:OECD:StandardAuditFile-Tax:PT_1.03_01 ../schemas/SAF-T.xsd");
        }

        public static XmlNodeList getArtigos()
        {
            System.Diagnostics.Debug.WriteLine("getArtigos()");
            XmlNodeList products = root.SelectNodes("//a:AuditFile/a:MasterFiles/a:Product",nsmgr);
            return products;
        }

    }
}