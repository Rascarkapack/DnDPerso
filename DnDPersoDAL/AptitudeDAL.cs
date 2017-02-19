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
    public class AptitudeDAL : BaseDAL<Aptitude>
    {
        public static List<AllAptitudes> GetAllAptitudes(int idClasse, int idRace)
        {
            FichePersoDndEntities db_context = null;

            List<AllAptitudes> result = new List<AllAptitudes>();
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.GetAllAptitudes(idClasse, idRace).ToList();
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
