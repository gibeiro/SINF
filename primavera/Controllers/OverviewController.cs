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

        // GET: api/overview/growth
        [HttpGet]
        [ActionName("Growth")]    
        [Route("overview/growth/{from?}/{to?}")]
        public List<Growth> Growth(string from, string to)
        {
            return Query.growth(from,to);
        }
               
        // GET: api/overview/clients
        [HttpGet]
        [ActionName("Clients")]
        [Route("overview/clients/{n?}")]
        public List<TopClientes> Clients(int n)
        {
            return Query.topClients(n);
        }

        // GET: api/overview/products
        [HttpGet]
        [ActionName("Products")]
        [Route("overview/products/{n?}")]
        public List<TopArtigos> Products(int n)
        {
            return Query.topProducts(n);
        }       

        // GET: api/overview/revenue
        [HttpGet]
        [ActionName("Revenue")]
        [Route("overview/revenue/{year?}")]
        public string Revenue(int year)
        {
            return Query.revenue(year); ;
        }

    }
}
