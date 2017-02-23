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
    public class ArgentDAL : BaseDAL<Argent>
    {
        public static List<GetArgentByPersonnage> GetArgentByPersonnage(int idPersonnage)
        {
            FichePersoDndEntities db_context = null;

            List<GetArgentByPersonnage> result = new List<GetArgentByPersonnage>();
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.GetArgentByPersonnage(idPersonnage).ToList();
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
