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
    public class CompetenceDAL : BaseDAL<Competence>
    {
        public static List<AllCompetenceByIdPersonnage> GetAllPouvoirByIdPersonnage(int idPersonnage)
        {
            FichePersoDndEntities db_context = null;

            List<AllCompetenceByIdPersonnage> result = new List<AllCompetenceByIdPersonnage>();
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.GetAllCompetenceByIdPersonnage(idPersonnage).ToList();
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
