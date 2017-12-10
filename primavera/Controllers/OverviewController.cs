using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using FirstREST.Database;

namespace FirstREST.Controllers
{
    public class OverviewController : ApiController
    {

        // ----- Para já está a retornar string mas probably vai ser diferente (IEnumerable probably)

        // GET: api/overview/growth?from=&to=
        [HttpGet]
        [ActionName("Growth")]    
        [Route("overview/growth/{from?}/{to?}")]
        public IHttpActionResult Growth(string from = "2016-01-01", string to = "2017-01-01") 
        { return Json(Query.overviewGrowth(from, to)); }
               
        // GET: api/overview/clients?limit=
        [HttpGet]
        [ActionName("Clients")]
        [Route("overview/clients/{limit?}")]
        public IHttpActionResult Clients(string limit = "10")
        { return Json(Query.overviewClients(int.Parse(limit))); }

        // GET: api/overview/products?limit=
        [HttpGet]
        [ActionName("Products")]
        [Route("overview/products/{limit?}")]
        public IHttpActionResult Products(string limit = "10")
        { return Json(Query.overviewProducts(int.Parse(limit))); }       

        // GET: api/overview/revenue?year=
        [HttpGet]
        [ActionName("Revenue")]
        [Route("overview/revenue/{year?}")]
        public IHttpActionResult Revenue(string year = "2016")
        { return Json(Query.overviewRevenue(int.Parse(year))); }

    }
}
