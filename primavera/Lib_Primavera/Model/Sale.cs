using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Sale
    {
        public string Customer { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public string Delivered { get; set; }
    }
}