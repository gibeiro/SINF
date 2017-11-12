using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace FirstREST.Lib_Primavera
{
    public class SaftParser
    {
        XmlDocument saft;
        public SaftParser(string path)
        {
            saft = new XmlDocument();
            saft.Load(path);
        }

        public XmlNodeList getArtigos()
        {

            XmlNode root = saft.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(saft.NameTable);
            return root.SelectNodes("AuditFile/MasterFiles/Product",nsmgr);
        }

    }
}