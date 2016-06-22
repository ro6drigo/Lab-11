using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Lab11_MVC_Chirinos.Filters;

namespace Lab11_MVC_Chirinos.Controllers
{
    public class ProductoController : Controller
    {
        private PRODUCTO producto = new PRODUCTO();
        private CATEGORIA categoria = new CATEGORIA();

        // GET: Producto
        public ActionResult Index()
        {
            return View(producto.listar());
        }

        public ActionResult Detalle(int id)
        {
            return View(producto.obtener(id));
        }

        public ActionResult Buscar(int criterio = 0)
        {
            ViewBag.CboxCategoria = categoria.listar();
            return View(producto.buscarXCategoria(criterio));
        }
    }
}