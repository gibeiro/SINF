using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Database;

/* Alguns nomes e paths mudaram mas
 * em termos de features continua tudo igual. 
 */
namespace FirstREST.Controllers
{
    public class CustomerController : ApiController
    {
        
        [HttpGet]
        [ActionName("Volume")]
        [Route("customer/volume/{id}/{from?}/{to?}")]
        /* 
            GET:     api/customer/volume?id=SOFRIO&from=2016-01-01&to=2017-01-01
            JSON:
                    [
                        {"gross":8875.43,"day":0},
                        {"gross":1564.87,"day":1},
                        {"gross":2413.15,"day":2}, ...
                    ]
         */
        public IHttpActionResult Volume(
            string id = null,
            string from = "2016-01-01",
            string to = "2017-01-01")
        {
            if (String.IsNullOrEmpty(id)) return BadRequest();
            else return Json(Query.customerVolume(id, from, to));
        }

       
        [HttpGet]
        [ActionName("Sales")]
        [Route("customer/sales/{id}/{from?}/{to?}")]
        /*
           GET:    api/customer/sales?id=SOFRIO&from=2016-01-01&to=2017-01-01
           JSON:   [
                       {"sales":2,"day":0},
                       {"sales":1,"day":1},
                       {"sales":1,"day":2}, ...
                   ]
        */
        public IHttpActionResult Sales(
            string id = null,
            string from = "2016-01-01",
            string to = "2017-01-01"
            )
        {
            if (String.IsNullOrEmpty(id)) return BadRequest();
            else return Json(Query.customerSales(id, from, to));
        }

        
        [HttpGet]
        [ActionName("Info")]
        [Route("customer/info/{id}")]
        /*
            GET:    api/customer/info?id=
            JSON:
                    {
                        "id":"SOFRIO",
                        "account":21111001,
                        "taxid":123456789,
                        "name":"Sofrio, Lda",
                        "address":"AV. DO ETERNO GELO, 88888",
                        "city":"POLO  NORTE",
                        "postalcode":1000,
                        "country":"PT",
                        "telephone":200267890,
                        "fax":200267899,
                        "website":"http://www.sofrio.com"
                    }
         */
        public IHttpActionResult Info(string id = null)
        {
            if (String.IsNullOrEmpty(id)) return BadRequest();
            else return Json(Query.customerInfo(id));
        }
       

        [HttpGet]
        [ActionName("Products")]
        [Route("customer/products/{id}/{limit?}")]
        /*
           GET: api/customer/products?id=SOFRIO&limit=1
           JSON: [{"gross":198388.8,"product":"A0003"}]
       */
        public IHttpActionResult Products(string id = null, string limit = "10")
        {
            if (String.IsNullOrEmpty(id)) return BadRequest();
            else return Json(Query.customerProducts(id,int.Parse(limit)));
        }
       
    }
}
