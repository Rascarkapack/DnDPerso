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
    public class EquipementDAL : BaseDAL<Equipement>
    {
        public static List<AllStuffByPersonnage> GetAllStuffByPersonnage(int idPersonnage)
        {
            FichePersoDndEntities db_context = null;

            List<AllStuffByPersonnage> result = new List<AllStuffByPersonnage>();
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.GetAllStuffByPersonnage(idPersonnage).ToList();
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
