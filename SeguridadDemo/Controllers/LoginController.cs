using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SeguridadDemo.Models;

namespace SeguridadDemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(new Usuario());
        }


        [HttpPost]
        public ActionResult Index(Usuario model)
        {

            if ((model.Login == "luis" && model.Password == "luis") ||
                (model.Login == "natalia" && model.Password == "natalia"))
            {
                var prin = new GenericPrincipal(new GenericIdentity(model.Login), new string[] {"Admin"});
             
                Session["u"] = model;

                Thread.CurrentPrincipal = prin;
                FormsAuthentication.SetAuthCookie(model.Login, false);

            }
            else
            {
                ModelState.AddModelError("","Datos de autenticacion incorrectos");
                return View(model);
            }



            return RedirectToAction("Index","Home");
        }
    }
}