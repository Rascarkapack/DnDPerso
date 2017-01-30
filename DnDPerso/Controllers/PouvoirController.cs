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
    public class PouvoirController : Controller
    {
        // GET: Pouvoir
        public ActionResult Index(int classe, int level)
        {
            FilterPouvoir model = new FilterPouvoir { Classe = classe, Niveau = level };
            
            return View(model);
        }

        public ActionResult SendFilterToList(FilterPouvoir model)
        {
            
            string HtmlContent = PouvoirBLL.GetListePouvoir(model);

            return Json(HtmlContent);
        }

        public ActionResult AddPouvoir(string pouvoirName)
        {
            int idPersonnage = Convert.ToInt32(Session["IdPersonnage"]);
            
            Pouvoir pouvoir = PouvoirBLL.GetPouvoirByName(pouvoirName);
            if (pouvoir != null)
            {
                PouvoirPersonnage pouvoirPersonnage = new PouvoirPersonnage
                {
                    IdPersonnage = idPersonnage,
                    IdPouvoir = pouvoir.Id
                };

                PouvoirPersonnageBLL.Add(pouvoirPersonnage);
            }
            return Json(idPersonnage);
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