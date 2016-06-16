using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Lab11_MVC_Chirinos.Filters;

namespace Lab11_MVC_Chirinos.Controllers
{
    public class UsuarioController : Controller
    {
        private USUARIO usuario = new USUARIO();

        // GET: Usuario
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(usuario.listar());
            }
            else
            {
                return View(usuario.buscar(criterio));
            }
        }

        public ActionResult Detalle(int id)
        {
            return View(usuario.obtener(id));
        }

        public ActionResult Mantenimiento(int id = 0)
        {
            return View(
                id == 0 ? new USUARIO() // Generar nuevo usuario
                        : usuario.obtener(id) //Retorna un id de un usuario existente
                );
        }

        public ActionResult Guardar(USUARIO model)
        {
            if (ModelState.IsValid)
            {
                model.mantenimiento();
                return Redirect("~/Usuario"); // Devuelve el index
            }
            else
            {
                return View("~/Views/Usuario/Mantenimiento.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            usuario.IDUSUARIO = id;
            usuario.eliminar();
            return Redirect("~/Usuario"); // Devuelve el index
        }
    }
}