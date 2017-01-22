using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDPersoEntities.Entities
{
    public class CharacterData
    {
        public string Nom { get; set; }
        public int? Niveau { get; set; }
        public int? IdClasse { get; set; }
        public int? Experience { get; set; }
        public int? IdRace { get; set; }
        public string CategorieTaille { get; set; }
        public int? Age { get; set; }
        public string Sexe { get; set; }
        public decimal? Taille { get; set; }
        public int? Poids { get; set; }
        public int? IdAlignement { get; set; }
        public int? IdDivinite { get; set; }
        public int? IdGroupeAventurier { get; set; }
        public int? PointAction { get; set; }
        public int? PVMax { get; set; }
        public string Personnalite { get; set; }
        public int? InitiativeDivers { get; set; }
        public int? CaracteristiqueForce { get; set; }
        public int? CaracteristiqueConstitution { get; set; }
        public int? CaracteristiqueDexterite { get; set; }
        public int? CaracteristiqueIntelligence { get; set; }
        public int? CaracteristiqueSagesse { get; set; }
        public int? CaracteristiqueCharisme { get; set; }
        public int? DefenseCADemiNiveau { get; set; }
        public int? DefenseCACaracteristique { get; set; }
        public int? DefenseCAClasse { get; set; }
        public int? DefenseCATalent { get; set; }
        public int? DefenseCADivers { get; set; }
        public int? DefenseVIGDemiNiveau { get; set; }
        public int? DefenseVIGCaracteristique { get; set; }
        public int? DefenseVIGClasse { get; set; }
        public int? DefenseVIGTalent { get; set; }
        public int? DefenseVIGDivers { get; set; }
        public int? DefenseREFDemiNiveau { get; set; }
        public int? DefenseREFCaracteristique { get; set; }
        public int? DefenseREFClasse { get; set; }
        public int? DefenseREFTalent { get; set; }
        public int? DefenseREFDivers { get; set; }
        public int? DefenseVOLDemiNiveau { get; set; }
        public int? DefenseVOLCaracteristique { get; set; }
        public int? DefenseVOLClasse { get; set; }
        public int? DefenseVOLTalent { get; set; }
        public int? DefenseVOLDivers { get; set; }
    }
}
