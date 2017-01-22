using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDPersoBLL;
using DnDPersoEntities;

namespace DnDPerso.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Utilisateur model)
        {
            if (ModelState.IsValid)
            {
                Utilisateur util = UtilisateurBLL.Login(model);

                if (!string.IsNullOrEmpty(util.Login) && !string.IsNullOrEmpty(util.Password))
                {
                    Session["UserSession"] = util;

                    return Json("OK");
                }
            }
            return Json("KO");
        }
    }
}