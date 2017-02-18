using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDPersoBLL;
using DnDPersoEntities;

namespace DnDPerso.Controllers
{
    public class TalentController : Controller
    {
        // GET: Talent
        public ActionResult Index()
        {
            IList<Talent> listTalents = TalentBLL.GetList();
            return View(listTalents);
        }

        public ActionResult AddTalent(string[] talentNames)
        {
            int idPersonnage = Convert.ToInt32(Session["IdPersonnage"]);
            foreach (string talentName in talentNames)
            {
                Talent talent = TalentBLL.GetTalentByName(talentName.Replace("'", "&apos;").Replace("\n", String.Empty).Trim());
                if (talent != null)
                {
                    TalentPersonnage talentPersonnage = new TalentPersonnage
                    {
                        IdPersonnage = idPersonnage,
                        IdTalent = talent.Id
                    };

                    TalentPersonnageBLL.Add(talentPersonnage);
                }
            }

            return Json(idPersonnage);
        }

        public ActionResult DeleteTalent(string idTalentPersonnage)
        {
            int idPersonnage = Convert.ToInt32(Session["IdPersonnage"]);
            TalentPersonnage talentPersonnage =
                TalentPersonnageBLL.GetList().SingleOrDefault(a => a.IdTalent == Convert.ToInt32(idTalentPersonnage));
            if (talentPersonnage != null) TalentPersonnageBLL.Delete(talentPersonnage.Id);

            return Json(idPersonnage);
        }
    }
}