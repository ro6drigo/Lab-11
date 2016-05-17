using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;

namespace Lab11_MVC_Chirinos.Controllers
{
    public class HomeController : Controller
    {
        private CATEGORIA categoria = new CATEGORIA();
        private PEDIDO pedido = new PEDIDO();
        private PRODUCTO producto = new PRODUCTO();
        private USUARIO usuario = new USUARIO();
        private TIPO_USUARIO tipo_usuario = new TIPO_USUARIO();
        private DETALLE_PEDIDO detalle_pedido = new DETALLE_PEDIDO();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // Categoria
        public ActionResult TVCategoria()
        {
            return View(categoria.listar());
        }

        public ActionResult TDCategoria(int id)
        {
            return View(categoria.obtener(id));
        }

        // Pedido
        public ActionResult TVPedido()
        {
            return View(pedido.listar());
        }

        public ActionResult TDPedido(int id)
        {
            return View(pedido.obtener(id));
        }

        // Producto
        public ActionResult TVProducto()
        {
            return View(producto.listar());
        }

        public ActionResult TDProducto(int id)
        {
            return View(producto.obtener(id));
        }

        // Usuario
        public ActionResult TVUsuario()
        {
            return View(usuario.listar());
        }

        public ActionResult TDUsuario(string id)
        {
            return View(usuario.obtener(id));
        }

        // Tipo Usuario
        public ActionResult TVTipoUsuario()
        {
            return View(tipo_usuario.listar());
        }

        public ActionResult TDTipoUsuario(int id)
        {
            return View(tipo_usuario.obtener(id));
        }

        // Detalle Pedido
        public ActionResult TVDetallePedido()
        {
            return View(detalle_pedido.listar());
        }
    }
}