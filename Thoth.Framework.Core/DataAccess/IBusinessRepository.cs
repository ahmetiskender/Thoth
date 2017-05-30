using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teos.Net.Papers.Framework.Core.DataAccess
{
    public interface IBusinessRepository<T>
    {
        T Get(int id);

        T Get(int id, DateTime date);

        T Add(T data);

        T Update(T data);

        void Delete(T data);

        List<T> GetAll();

        List<T> GetAll(DateTime date);

        List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> pregs);

        List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> pregs, DateTime date);

        IQueryable<T> GetAllQueryable();

        IQueryable<T> GetAllQueryable(System.Linq.Expressions.Expression<Func<T, bool>> pregs);


    }
}
