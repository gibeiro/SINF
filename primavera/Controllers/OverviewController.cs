using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Database;
using FirstREST.Lib_Primavera.Model;
using FirstREST.Lib_Primavera.Model.Custom;

namespace FirstREST.Controllers
{
    public class OverviewController : ApiController
    {

        // ----- Para já está a retornar string mas probably vai ser diferente (IEnumerable probably)

        // GET: api/overview/growth?from=&to=
        [HttpGet]
        [ActionName("Growth")]    
        [Route("overview/growth/{from?}/{to?}")]
        public List<Growth> Growth(string from = "2016-01-01", string to = "2017-01-01") 
        { return Query.growth(from, to); }
               
        // GET: api/overview/clients?limit=
        [HttpGet]
        [ActionName("Clients")]
        [Route("overview/clients/{limit?}")]
        public List<TopClientes> Clients(string limit = "10")
        { return Query.topClients(int.Parse(limit)); }

        // GET: api/overview/products?limit=
        [HttpGet]
        [ActionName("Products")]
        [Route("overview/products/{limit?}")]
        public List<TopArtigos> Products(string limit = "10")
        { return Query.topProducts(int.Parse(limit)); }       

        // GET: api/overview/revenue?year=
        [HttpGet]
        [ActionName("Revenue")]
        [Route("overview/revenue/{year?}")]
        public Revenue Revenue(string year = "2016")
        { return Query.revenue(int.Parse(year)); }

    }
}
