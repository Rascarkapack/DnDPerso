using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDPersoDAL.Base;
using DnDPersoEntities.Entities;
using DnDPersoEntities;
using DnDPersoEntities.Interfaces;
using DnDPersoDAL.Generated.Bdd;

namespace DnDPersoDAL
{
    public class PersonnageDAL : BaseDAL<Personnage>
    {
        public static void SaveCharacterData(int idUser, int idCharacter, CharacterData model)
        {
            FichePersoDndEntities db_context = null;
            string Nom = model.Nom;
            int? Niveau = model.Niveau;
            int? IdClasse = model.IdClasse;
            int? Experience = model.Experience;
            int? IdRace = model.IdRace;
            string CategorieTaille = model.CategorieTaille;
            int? Age = model.Age;
            string Sexe = model.Sexe;
            int? Taille = Convert.ToInt32(model.Taille);
            int? Poids = model.Poids;
            int? IdAlignement = model.IdAlignement;
            int? IdDivinite = model.IdDivinite;
           string GroupeAventurier = model.GroupeAventurier;
            int? PointAction = model.PointAction;
            int? PVMax = model.PVMax;
            string Personnalite = model.Personnalite;
            int? InitiativeDivers = model.InitiativeDivers;
            int? CaracteristiqueForce = model.CaracteristiqueForce;
            int? CaracteristiqueConstitution = model.CaracteristiqueConstitution;
            int? CaracteristiqueDexterite = model.CaracteristiqueDexterite;
            int? CaracteristiqueIntelligence = model.CaracteristiqueIntelligence;
            int? CaracteristiqueSagesse = model.CaracteristiqueSagesse;
            int? CaracteristiqueCharisme = model.CaracteristiqueCharisme;
            int? DefenseCADemiNiveau = model.DefenseCADemiNiveau;
            int? DefenseCACaracteristique = model.DefenseCACaracteristique;
            int? DefenseCAClasse = model.DefenseCAClasse;
            int? DefenseCATalent = model.DefenseCATalent;
            int? DefenseCADivers = model.DefenseCADivers;
            int? DefenseVIGDemiNiveau = model.DefenseVIGDemiNiveau;
            int? DefenseVIGCaracteristique = model.DefenseVIGCaracteristique;
            int? DefenseVIGClasse = model.DefenseVIGClasse;
            int? DefenseVIGTalent = model.DefenseVIGTalent;
            int? DefenseVIGDivers = model.DefenseVIGDivers;
            int? DefenseREFDemiNiveau = model.DefenseREFDemiNiveau;
            int? DefenseREFCaracteristique = model.DefenseREFCaracteristique;
            int? DefenseREFClasse = model.DefenseREFClasse;
            int? DefenseREFTalent = model.DefenseREFTalent;
            int? DefenseREFDivers = model.DefenseREFDivers;
            int? DefenseVOLDemiNiveau = model.DefenseVOLDemiNiveau;
            int? DefenseVOLCaracteristique = model.DefenseVOLCaracteristique;
            int? DefenseVOLClasse = model.DefenseVOLClasse;
            int? DefenseVOLTalent = model.DefenseVOLTalent;
            int? DefenseVOLDivers = model.DefenseVOLDivers;
            int? ModCaracAttaque = model.ModCaracAttaque;
            int? ModManiAttaque = model.ModManiAttaque;
            int? ModTalentAttaque = model.ModTalentAttaque;
            int? ModClasseAttaque = model.ModClasseAttaque;
            int? ModCaracDegat = model.ModCaracDegat;
            int? ModTalentDegat = model.ModTalentDegat;

            try
            {
                db_context = new FichePersoDndEntities();
                db_context.SetCharacterData(idUser, idCharacter, Nom, Niveau, IdClasse, Experience, IdRace, CategorieTaille, Age, Sexe, Taille, Poids, IdAlignement, IdDivinite, GroupeAventurier, PointAction, PVMax, Personnalite, InitiativeDivers,
                    CaracteristiqueForce, CaracteristiqueConstitution, CaracteristiqueDexterite, CaracteristiqueIntelligence, CaracteristiqueSagesse, CaracteristiqueCharisme, DefenseCADemiNiveau, DefenseCACaracteristique, DefenseCAClasse,
                    DefenseCATalent, DefenseCADivers, DefenseVIGDemiNiveau, DefenseVIGCaracteristique, DefenseVIGClasse, DefenseVIGTalent, DefenseVIGDivers, DefenseREFDemiNiveau, DefenseREFCaracteristique, DefenseREFClasse, DefenseREFTalent,
                    DefenseREFDivers, DefenseVOLDemiNiveau, DefenseVOLCaracteristique, DefenseVOLClasse, DefenseVOLTalent, DefenseVOLDivers, ModCaracAttaque, ModManiAttaque, ModTalentAttaque, ModClasseAttaque
                    , ModCaracDegat, ModTalentDegat);
            }
            catch(Exception e)
            { }
            finally
            {
                if (db_context != null)
                {
                    db_context.Dispose();
                    db_context = null;
                }
            }

        }

        public static CharacterData GetCharacterData(int idPersonnage)
        {
            FichePersoDndEntities db_context = null;
            CharacterData result = new CharacterData();
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.GetCharacterData(idPersonnage).FirstOrDefault();
            }
            finally
            {
                if (db_context != null)
                {
                    db_context.Dispose();
                    db_context = null;
                }
            }

            return result;
        }
    }
}
