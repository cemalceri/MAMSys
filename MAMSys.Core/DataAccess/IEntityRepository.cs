using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MAMSys.Core.Entities;

namespace MAMSys.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Getir(Expression<Func<T, bool>> filter);
        IList<T> GetirListe(Expression<Func<T, bool>> filter = null);
        T Ekle(T entity);
        T Guncelle(T entity);
        T Sil(T entity);

    }
}
