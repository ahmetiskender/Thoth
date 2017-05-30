using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;

namespace Thoth.Framework.Core.Abstracts.BusinessLayer
{
    public interface IBusiness<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> pregs = null);

        List<T> GetAll(DateTime date, Expression<Func<T, bool>> pregs = null);

        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> pregs = null);

        T Get(int id);

        T Get(int id, DateTime date);

        T Add(int userId, T data);

        T Update(int userId, T data);

        void Delete(int userId, T data);


    }
}