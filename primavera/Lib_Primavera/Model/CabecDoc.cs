using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class CabecDoc
    {
        public string id
        {
            get;
            set;
        }

        public DateTime Data
        {
            get;
            set;
        }

        public string Entidade
        {
            get;
            set;
        }

        public string NumDoc
        {
            get;
            set;
        }

        public string NumContribuinte
        {
            get;
            set;
        }

        public string TotalMerc
        {
            get;
            set;
        }

        public string TotalIVA
        {
            get;
            set;
        }

        public List<Model.LinhaDocVenda> LinhasDoc
        {
            get;
            set;
        }

    }
}