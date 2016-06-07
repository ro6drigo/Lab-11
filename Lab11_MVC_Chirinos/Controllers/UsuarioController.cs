﻿using System;
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
        public ActionResult Index()
        {
            return View(usuario.listar());
        }

        public ActionResult Detalle(string id)
        {
            return View(usuario.obtener(id));
        }

        public ActionResult Mantenimiento(string id = "")
        {
            return View(
                id == "" && id == null ? new USUARIO() // Generar nuevo usuario
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

        public ActionResult Eliminar(string id)
        {
            usuario.IDUSUARIO = id;
            usuario.eliminar();
            return Redirect("~/Usuario"); // Devuelve el index
        }
    }
}