using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IQSELFHOSTAPI.Repository
{
    public interface ICrudRepository<T>
    {
        bool Insert(T entities, ref Exception exception);
        bool ReturnModelInsert(T entities, ref T resultModel, ref Exception excection);
        bool Update(T entities, ref Exception exception);
        bool Delete(T entities, ref Exception exception);
        bool GetById(int id, ref T gyIdModel, ref Exception exception);
        bool GetList(ref List<T> List, ref Exception exception);
        bool GetList(Expression<Func<T, bool>> expression, ref List<T> List, ref Exception exception);
        bool Delete(IEnumerable<T> entities, ref Exception exception);
        bool Insert(IEnumerable<T> entities, ref Exception exception);
        bool Update(IEnumerable<T> entities, ref Exception exception);
    }
}