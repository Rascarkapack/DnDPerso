using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDPersoDAL.Base;
using DnDPersoEntities.Interfaces;

namespace DnDPersoBLL.Base
{
    public class BaseBLL<T> where T : class, IEntity
    {
        public static void Add(T item)
        {
            BaseDAL<T>.DataAccessAdd(item);
        }

        public static int AddWithReturn(T item)
        {
            return BaseDAL<T>.DataAccessAddWithReturn(item);
        }

        public static void AddRange(IList<T> entitiesToAdd)
        {
            BaseDAL<T>.DataAccessAddRange(entitiesToAdd);
        }

        public static T Get(int id)
        {
            return BaseDAL<T>.DataAccessGet(id);
        }

        public static IList<T> GetList()
        {
            return BaseDAL<T>.DataAccessGetList();
        }

        public static void Update(T item)
        {
            BaseDAL<T>.DataAccessUpdate(item);
        }

        public static bool Delete(int id)
        {
            return BaseDAL<T>.DataAccessDelete(id);
        }

        public static List<T> GetRList()
        {
            return BaseDAL<T>.DataAccessGetRList();
        }
    }
}
