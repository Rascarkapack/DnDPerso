using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DnDPersoEntities
{
    public partial class CharacterData
    {
        public List<SelectListItem> Classes { get; set; }
        public List<SelectListItem> Races { get; set; }
        public List<SelectListItem> Alignements { get; set; }
        public List<SelectListItem> Divinites { get; set; }

    }
} ;
