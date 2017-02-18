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
    public class TalentDAL : BaseDAL<Talent>
    {
        public static List<AllTalentByIdPersonnage> GetAllPouvoirByIdPersonnage(int idPersonnage)
        {
            FichePersoDndEntities db_context = null;

            List<AllTalentByIdPersonnage> result = new List<AllTalentByIdPersonnage>();
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.GetAllTalentByIdPersonnage(idPersonnage).ToList();
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

        public static Talent GetTalentByName(string name)
        {
            FichePersoDndEntities db_context = null;

            Talent result = null;
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.Talent.FirstOrDefault(a => a.Libelle == name);
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
