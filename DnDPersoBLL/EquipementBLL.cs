using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDPersoBLL.Base;
using DnDPersoDAL;
using DnDPersoEntities;

namespace DnDPersoBLL
{
    public class EquipementBLL : BaseBLL<Equipement>
    {
        public static List<AllStuffByPersonnage> GetAllStuffByPersonnage(int idPersonnage)
        {
            return EquipementDAL.GetAllStuffByPersonnage(idPersonnage);
        }
    }
}
