using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDPersoBLL;
using DnDPersoEntities;

namespace DnDPerso.Controllers
{
    public class SelectionPersonnageController : Controller
    {
        // GET: SelectionPersonnage
        public ActionResult Index()
        {
            Utilisateur util = Session["UserSession"] as Utilisateur;
            List<PersonnageByUtilisateur> listPerso = new List<PersonnageByUtilisateur>();
            if (util != null)
            {
                listPerso = UtilisateurPersonnageBLL.GetAllPersonnageByUtilisateur(util.Id);
            }
            return View(listPerso);
        }
    }
}