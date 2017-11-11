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
        public string Growth()
        {
            return "Growth";
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
        [Route("api/overview/clients/top/{n?}")]
        public List<Lib_Primavera.Model.Cliente> TopClients(int? n = 10)
        {
            return Lib_Primavera.PriIntegration.TopClientes(n);
        }

        // GET: api/overview/products
        [HttpGet]
        [ActionName("Products")]
        public IEnumerable<Lib_Primavera.Model.Custom.TopArtigos> Products()
        {
            return Lib_Primavera.PriIntegration.TopArtigos();
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
