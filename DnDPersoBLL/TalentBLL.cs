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
    public class TalentBLL : BaseBLL<Talent>
    {
        public static List<AllTalentByIdPersonnage> GetAllTalentByIdPersonnage(int idPersonnage)
        {
            return TalentDAL.GetAllPouvoirByIdPersonnage(idPersonnage);
        }
    }
}
