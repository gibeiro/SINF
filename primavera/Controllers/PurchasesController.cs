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
        
        [HttpGet]
        [ActionName("Latest")]
        [Route("purchases/latest/{limit?}")]
        /*
        Útimos produtos comprados (lista).
        http://localhost:49822/api/purchases/latest?limit=10
        [{
            "totalcost":3171.15,
            "quantity":87,
            "productname":"Mesa p/ PC",
            "productcode":"A0005"
        },...]
        */
        public IHttpActionResult Latest(string limit = "10")
        { return Json(Query.purchasesLatest(int.Parse(limit))); }

       
        [HttpGet]
        [ActionName("Volume")]
        [Route("purchases/volume/{from?}/{to?}")]
        /*
        Número de compras por dia (Line chart).
        http://localhost:49822/api/purchases/volume/from=2016-01-01&to=2017-01-01
        [{"purchases":3,"date":"2016-01-15","day":14},...]
        */
        public IHttpActionResult Volume(string from = "2016-01-01", string to = "2017-01-01")
        { return Json(Query.purchasesVolume(from, to)); }


        // GET: api/sales/expense?from=&to=
        // expense(€) per day between "from" and "to"
        [HttpGet]
        [ActionName("Expenditure")]
        [Route("purchases/expenditure/{from?}/{to?}")]
        /*
        Gastos em compras por dia (Line chart).
        http://localhost:49822/api/purchases/expenditure/from=2016-01-01&to=2017-01-01
        [{"cost":3806.8,"date":"2016-01-15","day":14},...]
        */
        public IHttpActionResult Expenditure(string from = "2016-01-01", string to = "2017-01-01")
        { return Json(Query.purchasesExpenditure(from, to)); }
    }
}
