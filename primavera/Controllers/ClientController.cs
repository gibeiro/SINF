﻿using System;
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
        // GET: api/client/info?id=<id>
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

        // GET: api/client/volume?id=<id>
        [HttpGet]
        [ActionName("Volume")]
        [Route("client/volume/{id?}")]
        public string Volume(int? id = null)
        {
            return "Volume: id: " + id;
        }
    }
}
