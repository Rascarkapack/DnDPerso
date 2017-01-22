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
        public ActionResult Index()
        {
            List<Classe> listClasses = ClasseBLL.GetRList();
            ViewData["listClasses"] = SetDropDownValues(listClasses, "Id", "Libelle", false);
            return View();
        }

        public ActionResult SendFilterToList(FilterPouvoir model)
        {
            string HtmlContent = PouvoirBLL.GetListePouvoir(model);

            return Json(HtmlContent);
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