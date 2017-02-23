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
    public class ArgentBLL : BaseBLL<Argent>
    {
        public static List<GetArgentByPersonnage> GetArgentByPersonnage(int idPersonnage)
        {
            return ArgentDAL.GetArgentByPersonnage(idPersonnage);
        }
    }
}
