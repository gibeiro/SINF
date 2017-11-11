using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Fornecedor
    {
        public string CodFornecedor
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public double Morada
        {
            get;
            set;
        }

        public string CodigoPostal
        {
            get;
            set;
        }

        public string Localidade
        {
            get;
            set;
        }
    }
}