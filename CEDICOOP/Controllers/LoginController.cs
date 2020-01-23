using CEDICOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CEDICOOP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ValidaNumero(Sesion sesion)
        {
            return RedirectToAction("Socio", "Socio");
        }
    }
}