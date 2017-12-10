using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using FirstREST.Database;

/*  "In Stock", "Unit Cost" e "Profit Margin"
 *  para já ficam de lado porque precisam de
 *  queries ao Primavera.
 *  "Unit Price" está incluido em /product/info.
 *  "Profit Over Time" está em /product/volume. -> compensava mudar o nome do pattern
 *  "Sales Volume" está em /product/sales. -> compensava mudar o nome do pattern
 *  Agora há uma pattern nova no recurso
 *  /product/prices que retorna o PVP do produto
 *  para todos os dias entre duas datas. -> era meter isso num line graph
 */

namespace FirstREST.Controllers
{
    public class ProductController : ApiController
    {
       
        [HttpGet]
        [ActionName("Volume")]
        [Route("product/volume/{id}/{from?}/{to?}")]
        /*
           GET:    api/product/volume?id=A0001&from=2016-01-01&to=2017-01-01
           JSON:
                   [
                       {"gross":2249.991,"day":0},
                       {"gross":3000.0,"day":3},
                       {"gross":2000.0,"day":5}, ...
                   ]
       */
        public IHttpActionResult Volume(
            string id = null, 
            string from = "2016-01-01", 
            string to = "2017-01-01"
            )
        {
            if (String.IsNullOrEmpty(id)) return BadRequest();
            else return Json(Query.productVolume(id, from, to));
        }

        
        [HttpGet]
        [ActionName("Sales")]
        [Route("product/sales/{id}/{from?}/{to?}")]
        /*
            GET:    api/product/sales?id=A0001&from=2016-01-01&to=2017-01-01
            JSON:
                [
                    {"sales":1,"day":0},
                    {"sales":1,"day":3},
                    {"sales":1,"day":5}, ...
                ]
        */
        public IHttpActionResult Sales(
            string id = null,
            string from = "2016-01-01",
            string to = "2017-01-01"
            )
        {
            if (String.IsNullOrEmpty(id)) return BadRequest();
            else return Json(Query.productSales(id, from, to));
        }

        
        [HttpGet]
        [ActionName("Info")]
        [Route("product/info/{id}")]
        /*
            GET:    api/product/info?id=A0001
            JSON:
                    {
                        "price":1000.0,
                        "type":"P",
                        "id":"A0001",
                        "group":"Computadores",
                        "description":"Pentium D925 Dual Core",
                        "code":"5601234901248"
                    }
        */
        public IHttpActionResult Info(string id = null)
        {
            if (String.IsNullOrEmpty(id)) return BadRequest();
            else return Json(Query.productInfo(id));
        }

        
        [HttpGet]
        [ActionName("Price")]
        [Route("product/price/{id}/{from?}/{to?}")]
        /*
        GET:    api/product/price?id=A0001&from=2016-01-01&to=2017-01-01
        JSON:
                [
                    {"price":749.997,"day":0},
                    {"price":1000.0,"day":3},
                    {"price":1000.0,"day":5}, ...
                ]
        */
        public IHttpActionResult Price(
            string id = null,
            string from = "2016-01-01",
            string to = "2017-01-01"
            )
        {
            if (String.IsNullOrEmpty(id)) return BadRequest();
            else return Json(Query.productPrice(id, from, to));
        }
       
    }
}
