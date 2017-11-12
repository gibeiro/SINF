using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;

namespace FirstREST.Controllers
{
    public class ClientController : ApiController
    {

        // client's top products
        [HttpGet]
        [ActionName("Info")]
        [Route("client/products/{id?}/{n?}")]
        public IEnumerable<Lib_Primavera.Model.Custom.TopArtigos> TopProducts(string id = null, string n = "5")
        {
            if (id == null) { return null; }
            return Lib_Primavera.PriIntegration.TopArtigosDeCliente(id,Convert.ToInt32(n));
        }

        [HttpGet]
        [ActionName("Info")]
        [Route("client/info/{id?}")]
        public Cliente Info(string id = null)
        {
            if (id == null) { return null; }
            Lib_Primavera.Model.Cliente cliente = Lib_Primavera.PriIntegration.GetCliente(id);
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
            return Lib_Primavera.PriIntegration.ListaClientes();
        }

        // GET: api/client/volume?id=<id>
        [HttpGet]
        [ActionName("Volume")]
        [Route("client/volume/{id?}")]
        public List<Lib_Primavera.Model.CabecDoc> Volume(string id = null)
        {
            return Lib_Primavera.PriIntegration.getClientPurchases(id);
        }
    }
}
