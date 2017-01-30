using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDPersoBLL.Base;
using DnDPersoEntities;
using DnDPersoEntities.Entities;
using DnDPersoDAL;

namespace DnDPersoBLL
{
    public class PouvoirBLL : BaseBLL<Pouvoir>
    {
        public static string GetListePouvoir(FilterPouvoir model)
        {
            return PouvoirDAL.GetListePouvoir(model);
        }

        public static List<AllPouvoirByIdPersonnage> GetAllPouvoirByIdPersonnage(int idPersonnage)
        {
            return PouvoirDAL.GetAllPouvoirByIdPersonnage(idPersonnage);
        }

        public static Pouvoir GetPouvoirByName(string name)
        {
            return PouvoirDAL.GetPouvoirByName(name);
        }
    }
}
