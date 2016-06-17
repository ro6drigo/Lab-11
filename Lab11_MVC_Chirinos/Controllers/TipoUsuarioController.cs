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
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(tipo_usuario.listar());
            }
            else
            {
                return View(tipo_usuario.buscar(criterio));
            }
        }

        public JsonResult CargarTipoUsuario(AnexGRID grid)
        {
            return Json(tipo_usuario.listarTipoGrilla(grid));
        }

        public ActionResult Detalle(int id)
        {
            return View(tipo_usuario.obtener(id));
        }

        public ActionResult Mantenimiento(int id = 0)
        {
            return View(
                id == 0 ? new TIPO_USUARIO() //para generar una nueva categoría
                        : tipo_usuario.obtener(id) //retorna un id de una categoría existente
                );
        }

        public ActionResult Guardar(TIPO_USUARIO model)
        {
            if (ModelState.IsValid)
            {
                model.mantenimiento();
                return Redirect("~/TipoUsuario"); //devuelve el index
            }
            else
            {
                return View("~/Views/TipoUsuario/Mantenimiento.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            tipo_usuario.IDTIPOUSUARIO = id;
            tipo_usuario.eliminar();
            return Redirect("~/TipoUsuario"); //devuelve el index
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                    criterio == null || criterio == "" ? tipo_usuario.listar()//devuelve la lista completa
                    : tipo_usuario.buscar(criterio)//devuelve la lista en base a la búsqueda
                    );
        }
    }
}