using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Database;

/* RIP disto para já */

namespace FirstREST.Controllers
{
    public class InventoryController : ApiController
    {
        [HttpGet]
        [ActionName("Products")]
        [Route("inventory/products")]
        /*
        Retorna todos os produtos no invantário (lista com text search)
        http://localhost:49822/api/inventory/products
        [{
            "to_receive":30,
            "total":599,
            "stock":569,
            "code":"A0001",
            "name":"Pentium D925 Dual Core",
            "category":"Computadores"
        }, ...]
        */
        public IHttpActionResult Products()
        { return Json(Query.inventoryProducts()); }
       

        [HttpGet]
        [ActionName("Groups")]
        [Route("inventory/groups")]
        /*
        Retorn a quantidade de stock por categoria/grupo de produto (pie chart)
        http://localhost:49822/api/inventory/groups
        [{"group":"Matï¿½rias Primas","total":2864},...]
        */
        public IHttpActionResult Groups()
        { return Json(Query.inventoryGroups()); }


        [HttpGet]
        [ActionName("Info")]
        [Route("inventory/info")]
        /*
        Retorn stock in_hand e stock to_receive (pie chart)
        http://localhost:49822/api/inventory/info
        {"in_hand":10132,"to_receive":1759}
        */
        public IHttpActionResult Info()
        { return Json(Query.inventoryInfo()); }


        [HttpGet]
        [ActionName("LowStock")]
        [Route("inventory/lowstock/{limit?}")]
        /*
        Retorna o número "limit" de produtos com menor stock
        http://localhost:49822/api/inventory/lowstock
        [{
        "code":"C0002",
        "name":"GT-15000 600x1200ppp 48bit USB SCSI",
        "in_hand":-795,
        "to_receive":0,
        "total":-795
        },...]
        */
        public IHttpActionResult LowStock(string limit = "10")
        { return Json(Query.inventoryLowStock(int.Parse(limit))); }
    }
}
