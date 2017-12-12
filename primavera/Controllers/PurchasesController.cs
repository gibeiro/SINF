using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Database;

/* RIP disto para já */

namespace FirstREST.Controllers
{
    public class PurchasesController : ApiController
    {
        // GET: api/sales/latest?limit=
        [HttpGet]
        [ActionName("Latest")]
        [Route("purchases/latest/{limit?}")]
        public IHttpActionResult Latest(string limit = "10")
        { return Json(Query.purchasesLatest(int.Parse(limit))); }

        // GET: api/sales/volume?from=&to=
        // nr. purchases per day between "from" and "to"
        [HttpGet]
        [ActionName("Volume")]
        [Route("purchases/volume/{from?}/{to?}")]
        public IHttpActionResult Volume(string from = "2016-01-01", string to = "2017-01-01")
        { return Json(Query.purchasesVolume(from, to)); }

        // GET: api/sales/expense?from=&to=
        // expense(€) per day between "from" and "to"
        [HttpGet]
        [ActionName("Expenditure")]
        [Route("purchases/expenditure/{from?}/{to?}")]
        public IHttpActionResult Expenditure(string from = "2016-01-01", string to = "2017-01-01")
        { return Json(Query.purchasesExpenditure(from, to)); }
    }
}
