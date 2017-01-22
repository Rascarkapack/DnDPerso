using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDPersoDAL.Base;
using DnDPersoDAL.Generated.Bdd;
using DnDPersoEntities;
using DnDPersoUtil.AESCrypt;
using DnDPersoUtil;

namespace DnDPersoDAL
{
    public class UtilisateurDAL : BaseDAL<Utilisateur>
    {
        public static Utilisateur GetUserByLoginPassword(Utilisateur util)
        {
            FichePersoDndEntities db_context = null;
            util.Password = AESCrypt.CryptString(util.Password, Constants.SiteKey);
            
            Utilisateur result = new Utilisateur();
            try
            {
                db_context = new FichePersoDndEntities();
                if (db_context.Utilisateur.Any(a=>a.Login == util.Login && a.Password == util.Password))
                {
                    result = db_context.Utilisateur.FirstOrDefault(a => a.Login == util.Login && a.Password == util.Password);
                }
                
            }
            finally
            {
                if (db_context != null)
                {
                    db_context.Dispose();
                    db_context = null;
                }
            }

            return result;
        }
    }
}
