using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDPersoDAL.Base;
using DnDPersoEntities.Entities;
using DnDPersoEntities;
using DnDPersoEntities.Interfaces;
using DnDPersoDAL.Generated.Bdd;

namespace DnDPersoDAL
{
    public class PouvoirDAL : BaseDAL<Pouvoir>
    {
        public static string GetListePouvoir(FilterPouvoir model)
        {
            FichePersoDndEntities db_context = null;
            int Classe = model.Classe;
            int Niveau = model.Niveau;
            string result = "";
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.ListePouvoirs(Classe, Niveau).ToString();
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
