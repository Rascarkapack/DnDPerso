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
    public class CompetenceBLL : BaseBLL<Competence>
    {
        public static List<AllCompetenceByIdPersonnage> GetAllCompetenceByIdPersonnage(int idPersonnage)
        {
            return CompetenceDAL.GetAllPouvoirByIdPersonnage(idPersonnage);
        }
    }
}
