using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Lab11_MVC_Chirinos.Filters;

namespace Lab11_MVC_Chirinos.Controllers
{
    public class TipoUsuarioController : Controller
    {
        private TIPO_USUARIO tipo_usuario = new TIPO_USUARIO();

        // GET: TipoUsuario
        public ActionResult Index()
        {
            return View(tipo_usuario.listar());
        }

        public ActionResult Detalle(int id)
        {
            return View(tipo_usuario.obtener(id));
        }
    }
}