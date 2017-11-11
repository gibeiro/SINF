using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class OverviewController : ApiController
    {

        // ----- Para já está a retornar string mas probably vai ser diferente (IEnumerable probably)

        // GET: api/overview/growth
        [HttpGet]
        [ActionName("Growth")]
        [Route("api/overview/growth/{y?}")]
        public List<Lib_Primavera.Model.Custom.Growth> Growth(int? y = 2016)
        {
            return Lib_Primavera.PriIntegration.GrowthYear(y);
        }

        // GET: api/overview/expenses
        [HttpGet]
        [ActionName("Expenses")]
        public string Expenses()
        {
            return "Expenses";
        }

        // GET: api/overview/clients/top
        [HttpGet]
        [ActionName("Clients")]
        [Route("api/overview/clients")]
        public List<Lib_Primavera.Model.Custom.TopClientes> TopClients(string n = "5")
        {
            return Lib_Primavera.PriIntegration.TopClientes(Convert.ToInt32(n));
        }

        // GET: api/overview/products
        [HttpGet]
        [ActionName("Products")]
        public IEnumerable<Lib_Primavera.Model.Custom.TopArtigos> Products(string n = "5")
        {
            return Lib_Primavera.PriIntegration.TopArtigos(Convert.ToInt32(n));
        }

        // GET: api/overview/revenue
        [HttpGet]
        [ActionName("Revenue")]
        public string Revenue()
        {
            return "Revenue";
        }

    }
}
