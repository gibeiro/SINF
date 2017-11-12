using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;
using System.Xml;

namespace FirstREST.Controllers
{
    public class ProductController : ApiController
    {

        // GET: api/product/volume?id=<id>
        [HttpGet]
        [ActionName("Volume")]
        [Route("product/volume/{id?}")]
        public List<Lib_Primavera.Model.Custom.SalesVol> Volume(string id = null,string y = "2016")
        {
            return Lib_Primavera.PriIntegration.SalesVolYear(id, Int32.Parse(y));
        }

        // GET: api/product/list
        [HttpGet]
        [ActionName("List")]
        [Route("product/list")]
        public List<Lib_Primavera.Model.Artigo> Get()
        {
            return Lib_Primavera.PriIntegration.ListaArtigos();
        }

        /*
        // GET: api/product/list
        [HttpGet]
        [ActionName("List")]
        [Route("product/list")]
        public List<Lib_Primavera.Model.Artigo> Get()
        {
            return Lib_Primavera.PriIntegration.ListaArtigos();
        }
        */
        // GET: api/product/get?id=<id>
        [HttpGet]
        [ActionName("Get")]
        [Route("product/get/{id?}")]
        public Lib_Primavera.Model.Artigo Get(string id = null)
        {
            return Lib_Primavera.PriIntegration.GetArtigo(id);
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
