using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using FirstREST.Database;

/*  Tudo igual a antes menos no Growth.
 *  Agora retorna uma JsonList um par
 *  {"profit":,"day":} para cada dia entre
 *  as datas "from" e "to".
 *  Eventualmente, quando forem feitas
 *  as queries ao Primavera, vai passar a
 *  ser uma lista de {"profit":,"day":,"cost":}.
 */

namespace FirstREST.Controllers
{
    public class OverviewController : ApiController
    {
       
        [HttpGet]
        [ActionName("Growth")]    
        [Route("overview/growth/{from?}/{to?}")]
        /*
           GET:    api/overview/growth?from=&to=
           JSON:
                   [
                       {"profit":7396.19,"day":0},
                       {"profit":10007.3,"day":1},
                       {"profit":568.62,"day":2}, ...
                   ]
       */
        public IHttpActionResult Growth(
            string from = "2016-01-01",
            string to = "2017-01-01"
        ){ return Json(Query.overviewGrowth(from, to)); }
        
        [HttpGet]
        [ActionName("Clients")]
        [Route("overview/clients/{limit?}")]
        /*   
            GET:    api/overview/clients?limit=1
            JSON:   [{"name":"Josï¿½ Maria Fernandes & Filhos, Lda.","gross":1369908.9699999997}]
        */
        public IHttpActionResult Clients(string limit = "10")
        { return Json(Query.overviewClients(int.Parse(limit))); }
        
        [HttpGet]
        [ActionName("Products")]
        [Route("overview/products/{limit?}")]
        /*
            GET:    api/overview/products?limit=1
            JSON:   [{"name":"A0002","gross":9260.15}]
        */
        public IHttpActionResult Products(string limit = "10")
        { return Json(Query.overviewProducts(int.Parse(limit))); }       
        
        [HttpGet]
        [ActionName("Revenue")]
        [Route("overview/revenue/{year?}")]
        /*
            GET:    api/overview/revenue?year=2016
            JSON:   {"current":3189747.6700000013,"previous":1529747.83}
        */
        public IHttpActionResult Revenue(string year = "2016")
        { return Json(Query.overviewRevenue(int.Parse(year))); }

    }
}
