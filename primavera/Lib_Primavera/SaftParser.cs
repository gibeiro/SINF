using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Text;

namespace FirstREST.Lib_Primavera
{
    public class SaftParser
    {
        public XmlDocument saft;
        public SaftParser(string path)
        {
            saft = new XmlDocument();
            saft.Load(path);
        }

    }
}