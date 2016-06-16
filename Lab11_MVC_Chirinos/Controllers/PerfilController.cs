using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Lab11_MVC_Chirinos.Filters;

namespace Lab11_MVC_Chirinos.Controllers
{
    public class PerfilController : Controller
    {
        private USUARIO usuario = new USUARIO();
        private TIPO_USUARIO tipo = new TIPO_USUARIO();
        // GET: Perfil
        public ActionResult Index()
        {
            ViewBag.tipo = tipo.listar();
            return View(usuario.obtener(SessionHelper.GetUser()));
            //return View();
        }

        public JsonResult Guardar(USUARIO model, HttpPostedFileBase Foto)
        {
            var rm = new ResponseModel();

            ModelState.Remove("Password");

            if (ModelState.IsValid)
            {
                rm = model.guardarFoto(Foto);
            }
            return Json(rm);
        }
    }
}
