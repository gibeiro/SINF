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

        // GET: api/overview/clients
        [HttpGet]
        [ActionName("Clients")]
        public string Clients()
        {
            return "Clients";
        }

        // GET: api/overview/products
        [HttpGet]
        [ActionName("Products")]
        public string Products()
        {
            return "Products";
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
