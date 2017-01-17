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
    }
}
