using CEDICOOP.DAO;
using CEDICOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

        [HttpPost]
        public ActionResult Login(Sesion sesion)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidaNumero(Sesion sesion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Notificacion<Usuario> n = new LoginDAO().ValidarUsario(sesion);
                    if (n != null)
                    {
                        Session["usuario"] = n.Model;
                        return RedirectToAction("Socio", "Socio");
                    }
                    else {
                        ModelState.AddModelError("ErrorGeneral", "Usuario y/o Contraseña incorrecto");

                    }
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
            return View("Login");
        }
    }
}