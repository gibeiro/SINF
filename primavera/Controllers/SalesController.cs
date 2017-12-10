using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Database;

namespace FirstREST.Controllers
{
    public class SalesController : ApiController
    {
        
        [HttpGet]
        [ActionName("Latest")]
        [Route("sales/latest/{limit?}")]
        /*
            GET:     api/sales/latest?limit=1
            JSON:    [{"customer":"J.M.F.","type":"FT","gross":2637.6,"date":"2016-10-07","status":"N"}]
        */
        public IHttpActionResult Latest(string limit = "10")
        { return Json(Query.salesLatest(int.Parse(limit))); }


        [HttpGet]
        [ActionName("Volume")]
        [Route("sales/volume/{from?}/{to?}")]
        /* 
           GET:     api/sales/volume?from=2016-01-01&to=2017-01-01
           JSON:
                   [
                       {"sales":5,"gross":35302.15,"day":0},
                       {"sales":3,"gross":15138.99,"day":1},
                       {"sales":3,"gross":3302.4700000000003,"day":2},
                       {"sales":5,"gross":18814.3,"day":3},
                       {"sales":4,"gross":11263.44,"day":4},...
                   ]
       */
        public IHttpActionResult Volume(string from = "2016-01-01", string to = "2017-01-01")
        { return Json(Query.salesVolume(from, to)); }
    }
}
