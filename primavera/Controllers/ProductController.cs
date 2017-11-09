using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/product/stock?id=<id>
        [HttpGet]
        [ActionName("Stock")]
        [Route("product/stock/{id?}")]
        public string Stock(int? id = null)
        {
            return "Stock: id: " + id;
        }

        // GET: api/product/price?id=<id>
        [HttpGet]
        [ActionName("Price")]
        [Route("product/price/{id?}")]
        public string Price(int? id = null)
        {
            return "Price: id: " + id;
        }

        // GET: api/product/volume?id=<id>
        [HttpGet]
        [ActionName("Volume")]
        [Route("product/volume/{id?}")]
        public string Volume(int? id = null)
        {
            return "Volume: id: " + id;
        }

        // GET: api/product/cost?id=<id>
        [HttpGet]
        [ActionName("Cost")]
        [Route("product/cost/{id?}")]
        public string Cost(int? id = null)
        {
            return "Cost: id: " + id;
        }

        // GET: api/product/margin?id=<id>
        [HttpGet]
        [ActionName("Margin")]
        [Route("product/margin/{id?}")]
        public string Margin(int? id = null)
        {
            return "Margin: id: " + id;
        }
    }
}
