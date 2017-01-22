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
    public class UtilisateurBLL : BaseBLL<Utilisateur>
    {
        public static Utilisateur Login(Utilisateur util)
        {
            return UtilisateurDAL.GetUserByLoginPassword(util);
        }
    }
}
