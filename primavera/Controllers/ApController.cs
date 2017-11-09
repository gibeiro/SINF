using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class ApController : ApiController
    {
        // GET: api/ap/kpi
        [HttpGet]
        [ActionName("KPI")]
        public string KPI()
        {
            return "KPI";
        }

        // GET: api/ap/ratio
        [HttpGet]
        [ActionName("Ratio")]
        public string Ratio()
        {
            return "Ratio";
        }

        // GET: api/ap/errors
        [HttpGet]
        [ActionName("Errors")]
        public string Errors()
        {
            return "Errors";
        }
    }
}
