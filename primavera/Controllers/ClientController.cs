using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;
using FirstREST.Lib_Primavera.Model.Custom;
using FirstREST.Database;

namespace FirstREST.Controllers
{
    public class ClientController : ApiController
    {

        // client's top products
        [HttpGet]
        [ActionName("Products")]
        [Route("client/products/{id?}")]
        public List<TopArtigos> TopProducts(string id = null, string n = "5")
        {
            if (id == null) { return null; }
            return Query.getClientTopProducts(id, Convert.ToInt32(n));
        }

        [HttpGet]
        [ActionName("Info")]
        [Route("client/info/{id?}")]
        public Cliente Info(string id = null)
        {
            if (id == null) { return null; }
            Cliente cliente = Query.getCustomer(id);
            if (cliente == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return cliente;
            }
        }

        // GET: api/client/list
        [HttpGet]
        [ActionName("List")]
        [Route("client/list")]
        public List<Cliente> List()
        {
            return Query.getCustomers();
        }

        // GET: api/client/volume?id=<id>
        [HttpGet]
        [ActionName("Volume")]
        [Route("client/volume/{id?}")]
        public List<CabecDoc> Volume(string id = null)
        {
            return Query.getClientPurchases(id);
        }
    }
}
