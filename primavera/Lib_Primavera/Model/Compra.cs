using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Compra
    {
        public string Entidade { get; set; }
        public string Artigo { get; set; }
        public double PrecUnit { get; set; }
        public int Quantidade { get; set; }
        public string DataDoc { get; set; }
    }
}