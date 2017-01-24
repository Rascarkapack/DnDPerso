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
    public class UtilisateurPersonnageBLL : BaseBLL<UtilisateurPersonnage>
    {
        public static List<PersonnageByUtilisateur> GetAllPersonnageByUtilisateur(int IdUtilisateur)
        {
            return UtilisateurPersonnageDAL.GetAllPersonnageByUtilisateur(IdUtilisateur);
        }
    }
}
