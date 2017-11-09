using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class InventoryController : ApiController
    {
        // GET: api/inventory/summary
        [HttpGet]
        [ActionName("Summary")]
        public string Summary()
        {
            return "Summary";
        }

        // GET: api/inventory/details
        [HttpGet]
        [ActionName("Details")]
        public string Details()
        {
            return "Details";
        }

        // GET: api/inventory/turnover?timeframe=month&nframes=10
        [HttpGet]
        [ActionName("Turnover")]
        [Route("inventory/turnover/{timeframe?}/{nframes?}")]
        public string Turnover(string timeframe = null, int? nframes = null)
        {
            return "Turnover: timeframe: " + timeframe + "; nframes: " + nframes;
        }
    }
}
