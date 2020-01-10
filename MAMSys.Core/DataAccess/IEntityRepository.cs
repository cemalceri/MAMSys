using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MAMSys.Core.Entities;

namespace MAMSys.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);

    }
}
