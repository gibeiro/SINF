using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class SalesController : ApiController
    {
        // GET: api/sales/activity
        [HttpGet]
        [ActionName("Activity")]
        public string Activity()
        {
            return "Activity";
        }

        // GET: api/sales/kpi?timeframe=month&nframes=10
        [HttpGet]
        [ActionName("KPI")]
        [Route("sales/kpi/{timeframe?}/{nframes?}")]
        public string KPI(string timeframe = null, int? nframes = null)
        {
            return "KPI: timeframe: " + timeframe + "; nframes: " + nframes;
        }
    }
}
