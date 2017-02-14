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
            CharacterData characterData = null;
            if (IdPersonnage != 0)
            {
                characterData = PersonnageBLL.GetCharacterData(IdPersonnage);
            }
            else
            {
                characterData = new CharacterData();
            }
            Session["IdPersonnage"] = IdPersonnage;

            List<Classe> listClasses = ClasseBLL.GetRList();
            characterData.Classes = SetDropDownValues(listClasses, "Id", "Libelle", false, characterData.IdClasse);

            List<Race> listRaces = RaceBLL.GetRList();
            characterData.Races = SetDropDownValues(listRaces, "Id", "Libelle", false, characterData.IdRace);

            List<Alignement> listAlignements = AlignementBLL.GetRList();
            characterData.Alignements = SetDropDownValues(listAlignements, "Id", "Libelle", false, characterData.IdAlignement);

            List<Divinite> listDivinites = DiviniteBLL.GetRList();
            characterData.Divinites = SetDropDownValues(listDivinites, "Id", "Libelle", false, characterData.IdDivinite);

            return View(characterData);
        }

        public ActionResult SaveCharacterData(CharacterData model)
        {
            try
            {
                if (Session["UserSession"] != null)
                {
                    int IdPersonnage = Convert.ToInt32(Session["IdPersonnage"]) ;
                    Utilisateur usr = Session["UserSession"] as Utilisateur;
                    PersonnageBLL.SaveCharacterData(usr.Id, IdPersonnage, model);
                }
            }
            catch (Exception e)
            {

            }

            return new EmptyResult();
        }

        #region partialEncartPouvoir

        public ActionResult EncartPouvoirsPartialView(int idPersonnage )
        {
            List<AllPouvoirByIdPersonnage> listAllPouvoirByIdPersonnages = new List<AllPouvoirByIdPersonnage>();
            try
            {
                listAllPouvoirByIdPersonnages = PouvoirBLL.GetAllPouvoirByIdPersonnage(idPersonnage);
            }
            catch (Exception)
            {
                throw;
            }
            return PartialView("EncartPouvoirsPartialView", listAllPouvoirByIdPersonnages);
        }

        #endregion

        #region partialEncartCompe
        public ActionResult EncartCompetencesPartialView(int idPersonnage)
        {
            List<AllCompetenceByIdPersonnage> listAllCompetenceByIdPersonnages = new List<AllCompetenceByIdPersonnage>();
            try
            {
                listAllCompetenceByIdPersonnages = CompetenceBLL.GetAllCompetenceByIdPersonnage(idPersonnage);
            }
            catch (Exception)
            {
                throw;
            }
            return PartialView("EncartCompetencesPartialView", listAllCompetenceByIdPersonnages);
        }

        #endregion

        #region partialEncartCompe
        public ActionResult EncartTalentsPartialView(int idPersonnage)
        {
            List<AllTalentByIdPersonnage> listAllTalentByIdPersonnages = new List<AllTalentByIdPersonnage>();
            try
            {
                listAllTalentByIdPersonnages = TalentBLL.GetAllTalentByIdPersonnage(idPersonnage);
            }
            catch (Exception)
            {
                throw;
            }
            return PartialView("EncartTalentsPartialView", listAllTalentByIdPersonnages);
        }

        public ActionResult EncartEquipementPartialView(int idPersonnage)
        {
            List<AllStuffByPersonnage> listAllStuffByPersonnage = new List<AllStuffByPersonnage>();
            try
            {
                listAllStuffByPersonnage = EquipementBLL.GetAllStuffByPersonnage(idPersonnage);
            }
            catch (Exception)
            {
                throw;
            }
            return PartialView("EncartEquipementPartialView", listAllStuffByPersonnage);
        }

        public ActionResult UpdateCompetence(string idCompePerso)
        {
            int idPersonnage = Convert.ToInt32(Session["IdPersonnage"]);
            CompetencePersonnage competencePersonnage = CompetencePersonnageBLL.Get(Convert.ToInt32(idCompePerso));
            competencePersonnage.Former = !competencePersonnage.Former;
            CompetencePersonnageBLL.Update(competencePersonnage);

            return Json(idPersonnage);
        }

        #endregion
        public static List<SelectListItem> SetDropDownValues<T>(IList<T> objects, string idProperty, string libelleProperty, bool hasEmptyElement, int idSelected)
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
                if (idSelected.ToString() == id && idSelected != 0)
                {
                    listTypesEntrants.Add(new SelectListItem
                    {
                        Selected = true,
                        Text = t.GetType().GetProperty(libelleProperty).GetValue(t, null).ToString(),
                        Value = id
                    });
                }
                else
                {
                    listTypesEntrants.Add(new SelectListItem
                    {
                        Selected = false,
                        Text = t.GetType().GetProperty(libelleProperty).GetValue(t, null).ToString(),
                        Value = id
                    });
                }

            }

            return listTypesEntrants;
        }
    }
}