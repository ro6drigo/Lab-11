using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Lab11_MVC_Chirinos.Filters;

namespace Lab11_MVC_Chirinos.Controllers
{
    [Autenticado]
    public class PerfilController : Controller
    {
        private USUARIO usuario = new USUARIO();
        private TIPO_USUARIO tipo = new TIPO_USUARIO();

        // GET: Perfil
        public ActionResult Index()
        {
            ViewBag.tipo = tipo.listar();
            return View(usuario.obtenerLogin(SessionHelper.GetUser().ToString()));
        }
    }
}