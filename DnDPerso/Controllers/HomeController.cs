using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDPersoBLL;
using DnDPersoEntities;
using DnDPersoEntities.Entities;

namespace DnDPerso.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int IdPersonnage)
        {
            List<Classe> listClasses = ClasseBLL.GetRList();
            ViewData["listClasses"] = SetDropDownValues(listClasses, "Id", "Libelle", false);

            List<Race> listRaces = RaceBLL.GetRList();
            ViewData["listRaces"] = SetDropDownValues(listRaces, "Id", "Libelle", false);

            List<Alignement> listAlignements = AlignementBLL.GetRList();
            ViewData["listAlignements"] = SetDropDownValues(listAlignements, "Id", "Libelle", false);

            List<Divinite> listDivinites = DiviniteBLL.GetRList();
            ViewData["listDivinites"] = SetDropDownValues(listDivinites, "Id", "Libelle", false);

            return View();
        }

        public ActionResult SaveCharacterData(CharacterData model)
        {
            try
            {
                if (Session["UserSession"] != null)
                {
                    Utilisateur util = Session["UserSession"] as Utilisateur;

                    PersonnageBLL.SaveCharacterData(util.Id, model);
                }
            }
            catch(Exception e)
            { }

            return new EmptyResult();
        }

        public static List<SelectListItem> SetDropDownValues<T>(IList<T> objects, string idProperty, string libelleProperty, bool hasEmptyElement)
        {
            List<SelectListItem> listTypesEntrants = new List<SelectListItem>();

            if (hasEmptyElement)
            {
                listTypesEntrants.Add(new SelectListItem
                {
                    Selected = true,
                    Text = string.Empty,
                    Value = "0"
                });
            }

            foreach (var t in objects)
            {
                string id = t.GetType().GetProperty(idProperty).GetValue(t, null).ToString();
                listTypesEntrants.Add(new SelectListItem
                {
                    Selected = false,
                    Text = t.GetType().GetProperty(libelleProperty).GetValue(t, null).ToString(),
                    Value = id
                });
            }

            return listTypesEntrants;
        }
    }
}