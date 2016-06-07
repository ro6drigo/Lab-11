using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Lab11_MVC_Chirinos.Filters;

namespace Lab11_MVC_Chirinos.Controllers
{
    public class PedidoController : Controller
    {
        private PEDIDO pedido = new PEDIDO();

        // GET: Pedido
        public ActionResult Index()
        {
            return View(pedido.listar());
        }

        public ActionResult Detalle(int id)
        {
            return View(pedido.obtener(id));
        }
    }
}