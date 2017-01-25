﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DnDPersoDAL.Generated.Bdd
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using DnDPersoEntities;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FichePersoDndEntities : DbContext
    {
        public FichePersoDndEntities()
            : base("name=FichePersoDndEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alignement> Alignement { get; set; }
        public virtual DbSet<AptitudeRaciale> AptitudeRaciale { get; set; }
        public virtual DbSet<Argent> Argent { get; set; }
        public virtual DbSet<Classe> Classe { get; set; }
        public virtual DbSet<Divinite> Divinite { get; set; }
        public virtual DbSet<Equipement> Equipement { get; set; }
        public virtual DbSet<GroupeAventurier> GroupeAventurier { get; set; }
        public virtual DbSet<Initiative> Initiative { get; set; }
        public virtual DbSet<Mouvement> Mouvement { get; set; }
        public virtual DbSet<Personnage> Personnage { get; set; }
        public virtual DbSet<Pouvoir> Pouvoir { get; set; }
        public virtual DbSet<PouvoirPersonnage> PouvoirPersonnage { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<RareteEquipement> RareteEquipement { get; set; }
        public virtual DbSet<Rituel> Rituel { get; set; }
        public virtual DbSet<RituelPersonnage> RituelPersonnage { get; set; }
        public virtual DbSet<Talent> Talent { get; set; }
        public virtual DbSet<TalentPersonnage> TalentPersonnage { get; set; }
        public virtual DbSet<TypeArgent> TypeArgent { get; set; }
        public virtual DbSet<TypeDes> TypeDes { get; set; }
        public virtual DbSet<TypeEquipement> TypeEquipement { get; set; }
        public virtual DbSet<TypePouvoir> TypePouvoir { get; set; }
        public virtual DbSet<Caracteristique> Caracteristique { get; set; }
        public virtual DbSet<CaracteristiquePersonnage> CaracteristiquePersonnage { get; set; }
        public virtual DbSet<Competence> Competence { get; set; }
        public virtual DbSet<CompetencePersonnage> CompetencePersonnage { get; set; }
        public virtual DbSet<Defense> Defense { get; set; }
        public virtual DbSet<DefensePersonnage> DefensePersonnage { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }
        public virtual DbSet<UtilisateurPersonnage> UtilisateurPersonnage { get; set; }
    
        public virtual ObjectResult<string> ListePouvoirs(Nullable<int> classe, Nullable<int> niveau)
        {
            var classeParameter = classe.HasValue ?
                new ObjectParameter("Classe", classe) :
                new ObjectParameter("Classe", typeof(int));
    
            var niveauParameter = niveau.HasValue ?
                new ObjectParameter("Niveau", niveau) :
                new ObjectParameter("Niveau", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("ListePouvoirs", classeParameter, niveauParameter);
        }
    
        public virtual int SetCharacterData(Nullable<int> idCharacter, string nom, Nullable<int> niveau, Nullable<int> idClasse, Nullable<int> experience, Nullable<int> idRace, string categorieTaille, Nullable<int> age, string sexe, Nullable<decimal> taille, Nullable<int> poids, Nullable<int> idAlignement, Nullable<int> idDivinite, Nullable<int> idGroupeAventurier, Nullable<int> pointAction, Nullable<int> pVMax, string personnalite, Nullable<int> initiativeDivers, Nullable<int> caracteristiqueForce, Nullable<int> caracteristiqueConstitution, Nullable<int> caracteristiqueDexterite, Nullable<int> caracteristiqueIntelligence, Nullable<int> caracteristiqueSagesse, Nullable<int> caracteristiqueCharisme, Nullable<int> defenseCADemiNiveau, Nullable<int> defenseCACaracteristique, Nullable<int> defenseCAClasse, Nullable<int> defenseCATalent, Nullable<int> defenseCADivers, Nullable<int> defenseVIGDemiNiveau, Nullable<int> defenseVIGCaracteristique, Nullable<int> defenseVIGClasse, Nullable<int> defenseVIGTalent, Nullable<int> defenseVIGDivers, Nullable<int> defenseREFDemiNiveau, Nullable<int> defenseREFCaracteristique, Nullable<int> defenseREFClasse, Nullable<int> defenseREFTalent, Nullable<int> defenseREFDivers, Nullable<int> defenseVOLDemiNiveau, Nullable<int> defenseVOLCaracteristique, Nullable<int> defenseVOLClasse, Nullable<int> defenseVOLTalent, Nullable<int> defenseVOLDivers)
        {
            var idCharacterParameter = idCharacter.HasValue ?
                new ObjectParameter("idCharacter", idCharacter) :
                new ObjectParameter("idCharacter", typeof(int));
    
            var nomParameter = nom != null ?
                new ObjectParameter("Nom", nom) :
                new ObjectParameter("Nom", typeof(string));
    
            var niveauParameter = niveau.HasValue ?
                new ObjectParameter("Niveau", niveau) :
                new ObjectParameter("Niveau", typeof(int));
    
            var idClasseParameter = idClasse.HasValue ?
                new ObjectParameter("IdClasse", idClasse) :
                new ObjectParameter("IdClasse", typeof(int));
    
            var experienceParameter = experience.HasValue ?
                new ObjectParameter("Experience", experience) :
                new ObjectParameter("Experience", typeof(int));
    
            var idRaceParameter = idRace.HasValue ?
                new ObjectParameter("IdRace", idRace) :
                new ObjectParameter("IdRace", typeof(int));
    
            var categorieTailleParameter = categorieTaille != null ?
                new ObjectParameter("CategorieTaille", categorieTaille) :
                new ObjectParameter("CategorieTaille", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var sexeParameter = sexe != null ?
                new ObjectParameter("Sexe", sexe) :
                new ObjectParameter("Sexe", typeof(string));
    
            var tailleParameter = taille.HasValue ?
                new ObjectParameter("Taille", taille) :
                new ObjectParameter("Taille", typeof(decimal));
    
            var poidsParameter = poids.HasValue ?
                new ObjectParameter("Poids", poids) :
                new ObjectParameter("Poids", typeof(int));
    
            var idAlignementParameter = idAlignement.HasValue ?
                new ObjectParameter("IdAlignement", idAlignement) :
                new ObjectParameter("IdAlignement", typeof(int));
    
            var idDiviniteParameter = idDivinite.HasValue ?
                new ObjectParameter("IdDivinite", idDivinite) :
                new ObjectParameter("IdDivinite", typeof(int));
    
            var idGroupeAventurierParameter = idGroupeAventurier.HasValue ?
                new ObjectParameter("IdGroupeAventurier", idGroupeAventurier) :
                new ObjectParameter("IdGroupeAventurier", typeof(int));
    
            var pointActionParameter = pointAction.HasValue ?
                new ObjectParameter("PointAction", pointAction) :
                new ObjectParameter("PointAction", typeof(int));
    
            var pVMaxParameter = pVMax.HasValue ?
                new ObjectParameter("PVMax", pVMax) :
                new ObjectParameter("PVMax", typeof(int));
    
            var personnaliteParameter = personnalite != null ?
                new ObjectParameter("Personnalite", personnalite) :
                new ObjectParameter("Personnalite", typeof(string));
    
            var initiativeDiversParameter = initiativeDivers.HasValue ?
                new ObjectParameter("InitiativeDivers", initiativeDivers) :
                new ObjectParameter("InitiativeDivers", typeof(int));
    
            var caracteristiqueForceParameter = caracteristiqueForce.HasValue ?
                new ObjectParameter("CaracteristiqueForce", caracteristiqueForce) :
                new ObjectParameter("CaracteristiqueForce", typeof(int));
    
            var caracteristiqueConstitutionParameter = caracteristiqueConstitution.HasValue ?
                new ObjectParameter("CaracteristiqueConstitution", caracteristiqueConstitution) :
                new ObjectParameter("CaracteristiqueConstitution", typeof(int));
    
            var caracteristiqueDexteriteParameter = caracteristiqueDexterite.HasValue ?
                new ObjectParameter("CaracteristiqueDexterite", caracteristiqueDexterite) :
                new ObjectParameter("CaracteristiqueDexterite", typeof(int));
    
            var caracteristiqueIntelligenceParameter = caracteristiqueIntelligence.HasValue ?
                new ObjectParameter("CaracteristiqueIntelligence", caracteristiqueIntelligence) :
                new ObjectParameter("CaracteristiqueIntelligence", typeof(int));
    
            var caracteristiqueSagesseParameter = caracteristiqueSagesse.HasValue ?
                new ObjectParameter("CaracteristiqueSagesse", caracteristiqueSagesse) :
                new ObjectParameter("CaracteristiqueSagesse", typeof(int));
    
            var caracteristiqueCharismeParameter = caracteristiqueCharisme.HasValue ?
                new ObjectParameter("CaracteristiqueCharisme", caracteristiqueCharisme) :
                new ObjectParameter("CaracteristiqueCharisme", typeof(int));
    
            var defenseCADemiNiveauParameter = defenseCADemiNiveau.HasValue ?
                new ObjectParameter("DefenseCADemiNiveau", defenseCADemiNiveau) :
                new ObjectParameter("DefenseCADemiNiveau", typeof(int));
    
            var defenseCACaracteristiqueParameter = defenseCACaracteristique.HasValue ?
                new ObjectParameter("DefenseCACaracteristique", defenseCACaracteristique) :
                new ObjectParameter("DefenseCACaracteristique", typeof(int));
    
            var defenseCAClasseParameter = defenseCAClasse.HasValue ?
                new ObjectParameter("DefenseCAClasse", defenseCAClasse) :
                new ObjectParameter("DefenseCAClasse", typeof(int));
    
            var defenseCATalentParameter = defenseCATalent.HasValue ?
                new ObjectParameter("DefenseCATalent", defenseCATalent) :
                new ObjectParameter("DefenseCATalent", typeof(int));
    
            var defenseCADiversParameter = defenseCADivers.HasValue ?
                new ObjectParameter("DefenseCADivers", defenseCADivers) :
                new ObjectParameter("DefenseCADivers", typeof(int));
    
            var defenseVIGDemiNiveauParameter = defenseVIGDemiNiveau.HasValue ?
                new ObjectParameter("DefenseVIGDemiNiveau", defenseVIGDemiNiveau) :
                new ObjectParameter("DefenseVIGDemiNiveau", typeof(int));
    
            var defenseVIGCaracteristiqueParameter = defenseVIGCaracteristique.HasValue ?
                new ObjectParameter("DefenseVIGCaracteristique", defenseVIGCaracteristique) :
                new ObjectParameter("DefenseVIGCaracteristique", typeof(int));
    
            var defenseVIGClasseParameter = defenseVIGClasse.HasValue ?
                new ObjectParameter("DefenseVIGClasse", defenseVIGClasse) :
                new ObjectParameter("DefenseVIGClasse", typeof(int));
    
            var defenseVIGTalentParameter = defenseVIGTalent.HasValue ?
                new ObjectParameter("DefenseVIGTalent", defenseVIGTalent) :
                new ObjectParameter("DefenseVIGTalent", typeof(int));
    
            var defenseVIGDiversParameter = defenseVIGDivers.HasValue ?
                new ObjectParameter("DefenseVIGDivers", defenseVIGDivers) :
                new ObjectParameter("DefenseVIGDivers", typeof(int));
    
            var defenseREFDemiNiveauParameter = defenseREFDemiNiveau.HasValue ?
                new ObjectParameter("DefenseREFDemiNiveau", defenseREFDemiNiveau) :
                new ObjectParameter("DefenseREFDemiNiveau", typeof(int));
    
            var defenseREFCaracteristiqueParameter = defenseREFCaracteristique.HasValue ?
                new ObjectParameter("DefenseREFCaracteristique", defenseREFCaracteristique) :
                new ObjectParameter("DefenseREFCaracteristique", typeof(int));
    
            var defenseREFClasseParameter = defenseREFClasse.HasValue ?
                new ObjectParameter("DefenseREFClasse", defenseREFClasse) :
                new ObjectParameter("DefenseREFClasse", typeof(int));
    
            var defenseREFTalentParameter = defenseREFTalent.HasValue ?
                new ObjectParameter("DefenseREFTalent", defenseREFTalent) :
                new ObjectParameter("DefenseREFTalent", typeof(int));
    
            var defenseREFDiversParameter = defenseREFDivers.HasValue ?
                new ObjectParameter("DefenseREFDivers", defenseREFDivers) :
                new ObjectParameter("DefenseREFDivers", typeof(int));
    
            var defenseVOLDemiNiveauParameter = defenseVOLDemiNiveau.HasValue ?
                new ObjectParameter("DefenseVOLDemiNiveau", defenseVOLDemiNiveau) :
                new ObjectParameter("DefenseVOLDemiNiveau", typeof(int));
    
            var defenseVOLCaracteristiqueParameter = defenseVOLCaracteristique.HasValue ?
                new ObjectParameter("DefenseVOLCaracteristique", defenseVOLCaracteristique) :
                new ObjectParameter("DefenseVOLCaracteristique", typeof(int));
    
            var defenseVOLClasseParameter = defenseVOLClasse.HasValue ?
                new ObjectParameter("DefenseVOLClasse", defenseVOLClasse) :
                new ObjectParameter("DefenseVOLClasse", typeof(int));
    
            var defenseVOLTalentParameter = defenseVOLTalent.HasValue ?
                new ObjectParameter("DefenseVOLTalent", defenseVOLTalent) :
                new ObjectParameter("DefenseVOLTalent", typeof(int));
    
            var defenseVOLDiversParameter = defenseVOLDivers.HasValue ?
                new ObjectParameter("DefenseVOLDivers", defenseVOLDivers) :
                new ObjectParameter("DefenseVOLDivers", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetCharacterData", idCharacterParameter, nomParameter, niveauParameter, idClasseParameter, experienceParameter, idRaceParameter, categorieTailleParameter, ageParameter, sexeParameter, tailleParameter, poidsParameter, idAlignementParameter, idDiviniteParameter, idGroupeAventurierParameter, pointActionParameter, pVMaxParameter, personnaliteParameter, initiativeDiversParameter, caracteristiqueForceParameter, caracteristiqueConstitutionParameter, caracteristiqueDexteriteParameter, caracteristiqueIntelligenceParameter, caracteristiqueSagesseParameter, caracteristiqueCharismeParameter, defenseCADemiNiveauParameter, defenseCACaracteristiqueParameter, defenseCAClasseParameter, defenseCATalentParameter, defenseCADiversParameter, defenseVIGDemiNiveauParameter, defenseVIGCaracteristiqueParameter, defenseVIGClasseParameter, defenseVIGTalentParameter, defenseVIGDiversParameter, defenseREFDemiNiveauParameter, defenseREFCaracteristiqueParameter, defenseREFClasseParameter, defenseREFTalentParameter, defenseREFDiversParameter, defenseVOLDemiNiveauParameter, defenseVOLCaracteristiqueParameter, defenseVOLClasseParameter, defenseVOLTalentParameter, defenseVOLDiversParameter);
        }
    
        public virtual ObjectResult<PersonnageByUtilisateur> GetAllPersonnageByUtilisateur(Nullable<int> idUtilisateur)
        {
            var idUtilisateurParameter = idUtilisateur.HasValue ?
                new ObjectParameter("IdUtilisateur", idUtilisateur) :
                new ObjectParameter("IdUtilisateur", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PersonnageByUtilisateur>("GetAllPersonnageByUtilisateur", idUtilisateurParameter);
        }
    
        public virtual ObjectResult<CharacterData> GetCharacterData(Nullable<int> characterId)
        {
            var characterIdParameter = characterId.HasValue ?
                new ObjectParameter("CharacterId", characterId) :
                new ObjectParameter("CharacterId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CharacterData>("GetCharacterData", characterIdParameter);
        }
    }
}
