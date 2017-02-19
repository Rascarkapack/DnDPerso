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
    public class AptitudeBLL : BaseBLL<Aptitude>
    {
        public static List<AllAptitudes> GetAllAptitudes(int idClasse, int idRace)
        {
            return AptitudeDAL.GetAllAptitudes(idClasse, idRace);
        }
    }
}
