using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Lab11_MVC_Chirinos.Filters;

namespace Lab11_MVC_Chirinos.Controllers
{
    public class DetallePedidoController : Controller
    {
        private DETALLE_PEDIDO detalle_pedido = new DETALLE_PEDIDO();

        // GET: DetallePedido
        public ActionResult Index()
        {
            return View(detalle_pedido.listar());
        }
    }
}