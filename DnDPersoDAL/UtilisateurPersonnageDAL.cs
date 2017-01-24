using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDPersoDAL.Base;
using DnDPersoDAL.Generated.Bdd;
using DnDPersoEntities;

namespace DnDPersoDAL
{
    public class UtilisateurPersonnageDAL : BaseDAL<UtilisateurPersonnage>
    {
        public static List<PersonnageByUtilisateur> GetAllPersonnageByUtilisateur(int IdUtilisateur)
        {
            FichePersoDndEntities db_context = null;
            List<PersonnageByUtilisateur> result = null;
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.GetAllPersonnageByUtilisateur(IdUtilisateur).ToList();
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
