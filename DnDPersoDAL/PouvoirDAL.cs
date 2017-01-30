﻿using System;
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
            int? Classe = model.Classe;
            int? Niveau = model.Niveau;
            string result = "";
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.ListePouvoirs(Classe, Niveau).FirstOrDefault();
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

        public static List<AllPouvoirByIdPersonnage> GetAllPouvoirByIdPersonnage(int idPersonnage)
        {
            FichePersoDndEntities db_context = null;

            List<AllPouvoirByIdPersonnage> result = new List<AllPouvoirByIdPersonnage>();
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.GetAllPouvoirByIdPersonnage(idPersonnage).ToList();
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

        public static Pouvoir GetPouvoirByName(string name)
        {
            FichePersoDndEntities db_context = null;
            
            Pouvoir result = null;
            try
            {
                db_context = new FichePersoDndEntities();
                result = db_context.Pouvoir.FirstOrDefault(a=>a.Libelle == name);
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
