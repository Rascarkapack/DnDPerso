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
                Talent talent = TalentBLL.GetTalentByName(talentName.Replace("'", "&apos;"));
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
    }
}