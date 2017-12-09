using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;
using FirstREST.Lib_Primavera.Model.Custom;
using FirstREST.Database;

namespace FirstREST.Controllers
{
    public class SalesController : ApiController
    {

        // GET: api/sales?limit=
        [HttpGet]
        [ActionName("Sales")]
        [Route("sales/{limit?}")]
        public List<Sale> Sales(string limit = "10")
        {
            return Query.sales(Int32.Parse(limit));
        }
        // GET: api/sales/volume?from=&to=
        [HttpGet]
        [ActionName("Volume")]
        [Route("sales/volume/{from?}/{to?}")]
        public List<SalesVolume> Volume(string from = "2016-01-01", string to = "2017-01-01")
        {
            if (String.Compare(from,to) >= 0 ) return null;
            return Query.volume(from, to);
        }
    }
}
