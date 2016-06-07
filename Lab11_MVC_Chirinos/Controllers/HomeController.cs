﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Lab11_MVC_Chirinos.Filters;

namespace Lab11_MVC_Chirinos.Controllers
{
    [Autenticado]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}