using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDPersoEntities;
using DnDPersoEntities.Interfaces;
using DnDPersoDAL.Generated.Bdd;

namespace DnDPersoDAL.Base
{
    public class BaseDAL<T> where T : class, IEntity
    {
        
        public static void DataAccessAdd(T item)
        {
            FichePersoDndEntities db_context = null;
            try
            {
                db_context = new FichePersoDndEntities();
                DbSet<T> DbSet = db_context.Set<T>();

                DbSet.Add(item);

                db_context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder outputLines = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.AppendLine(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));

                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }

                //logger.Error(outputLines.ToString());
                throw;
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw;
            }
            finally
            {
                if (db_context != null)
                {
                    db_context.Dispose();
                    db_context = null;
                }
            }
        }

        public static int DataAccessAddWithReturn(T item)
        {
            int result = 0;
            FichePersoDndEntities db_context = null;
            try
            {
                db_context = new FichePersoDndEntities();
                DbSet<T> DbSet = db_context.Set<T>();

                DbSet.Add(item);

                db_context.SaveChanges();

                result = item.Id;
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder outputLines = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.AppendLine(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));

                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }

                //logger.Error(outputLines.ToString());
                throw;
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw;
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

        public static void DataAccessAddRange(IList<T> entitiesToAdd)
        {
            FichePersoDndEntities db = null;
            try
            {
                db = new FichePersoDndEntities();
                DbSet<T> DbSet = db.Set<T>();

                DbSet.AddRange(entitiesToAdd);

                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder outputLines = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.AppendLine(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));

                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }

                //logger.Error(outputLines.ToString());
                throw;
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public static T DataAccessGet(int id)
        {
            FichePersoDndEntities db_context = null;
            T item = null;

            try
            {
                db_context = new FichePersoDndEntities();
                DbSet<T> DbSet = db_context.Set<T>();

                item = DbSet.FirstOrDefault(i => i.Id == id);
            }
            finally
            {
                if (db_context != null)
                {
                    db_context.Dispose();
                    db_context = null;
                }
            }
            return item;
        }





        public static IList<T> DataAccessGetList()
        {
            FichePersoDndEntities db_context = null;
            IList<T> list = null;

            try
            {
                db_context = new FichePersoDndEntities();

                DbSet<T> DbSet = db_context.Set<T>();
                list = DbSet.ToList();
            }
            finally
            {
                if (db_context != null)
                {
                    db_context.Dispose();
                    db_context = null;
                }
            }
            return list;
        }

        public static void DataAccessUpdate(T item)
        {
            FichePersoDndEntities db_context = null;
            try
            {
                db_context = new FichePersoDndEntities();
                DbSet<T> DbSet = db_context.Set<T>();

                DbSet.Attach(item);
                db_context.Entry(item).State = EntityState.Modified;
                db_context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder outputLines = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.AppendLine(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));

                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }

                //logger.Error(outputLines.ToString());
                throw;
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw;
            }
            finally
            {
                if (db_context != null)
                {
                    db_context.Dispose();
                    db_context = null;
                }
            }
        }

        public static bool DataAccessDelete(int itemId)
        {
            FichePersoDndEntities db_context = null;
            T item = null;
            bool result = false;

            try
            {
                db_context = new FichePersoDndEntities();
                DbSet<T> DbSet = db_context.Set<T>();

                item = DbSet.SingleOrDefault(i => i.Id == itemId);

                DbSet.Remove(item);

                db_context.SaveChanges();
                result = true;
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


        public static List<T> DataAccessGetRList()
        {
            FichePersoDndEntities db_context = null;
            List<T> list = null;

            try
            {
                db_context = new FichePersoDndEntities();

                DbSet<T> DbSet = db_context.Set<T>();
                list = DbSet.ToList();
            }
            finally
            {
                if (db_context != null)
                {
                    db_context.Dispose();
                    db_context = null;
                }
            }
            return list;
        }

    }
}
