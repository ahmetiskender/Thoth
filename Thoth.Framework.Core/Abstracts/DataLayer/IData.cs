using Thoth.Framework.Core.Abstracts.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Thoth.Framework.Core.Abstracts.DataLayer
{
    public interface IData<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> pregs = null);

        List<T> GetAll(DateTime date, Expression<Func<T, bool>> pregs = null);

        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> pregs = null);

        T Get(int id);

        T Get(int id, DateTime date);

        T Add(T data);

        T Update(T data);

        void Delete(T data);


    }
}