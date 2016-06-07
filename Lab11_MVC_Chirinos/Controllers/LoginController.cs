using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;

namespace Lab11_MVC_Chirinos.Controllers
{
    public class LoginController : Controller
    {
        private USUARIO usuario = new USUARIO();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string Email, string Password)
        {
            var rm = usuario.Acceder(Email, Password);

            if (rm.response)
            {
                rm.href = Url.Content("~/Home");
            }
            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }
    }
}