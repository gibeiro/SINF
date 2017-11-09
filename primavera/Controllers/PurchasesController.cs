using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class PurchasesController : ApiController
    {
        // GET: api/purchases/history
        [HttpGet]
        [ActionName("History")]
        public string History()
        {
            return "History";
        }

        // GET: api/purchases/distribution
        [HttpGet]
        [ActionName("Distribution")]
        public string Distribution()
        {
            return "Distribution";
        }

        // GET: api/purchases/budget?timeframe=month&nframes=10
        [HttpGet]
        [ActionName("Budget")]
        [Route("purchases/budget/{timeframe?}/{nframes?}")]
        public string Budget(string timeframe = null, int? nframes = null)
        {
            return "Budget: timeframe: " + timeframe + "; nframes: " + nframes;
        }
    }
}
