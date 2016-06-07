using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Lab11_MVC_Chirinos.Filters;

namespace Lab11_MVC_Chirinos.Controllers
{
    public class CategoriaController : Controller
    {
        private CATEGORIA categoria = new CATEGORIA();

        // GET: Categoria
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(categoria.listar());
            }
            else
            {
                return View(categoria.buscar(criterio));
            }
        }

        public ActionResult Detalle(int id)
        {
            return View(categoria.obtener(id));
        }

        public ActionResult Mantenimiento(int id = 0)
        {
            return View(
                id == 0 ? new CATEGORIA() // Generar nueva categoria
                        : categoria.obtener(id) //Retorna un id de una categoria existente
                );
        }

        public ActionResult Mantenimiento(string id = "")
        {
            return View(
                id == "" || id == null ? new USUARIO() // Generar nuevo usuario
                        : usuario.obtener(id) //Retorna un id de un usuario existente
                );
        }

        public ActionResult Guardar(CATEGORIA model)
        {
            if (ModelState.IsValid)
            {
                model.mantenimiento();
                return Redirect("~/Categoria"); // Devuelve el index
            }
            else
            {
                return View("~/Views/Categoria/Mantenimiento.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            categoria.IDCATEGORIA = id;
            categoria.eliminar();
            return Redirect("~/Categoria"); // Devuelve el index
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                    (criterio == null || criterio == "") ? categoria.listar()
                    : categoria.buscar(criterio)
                );
        }
    }
}