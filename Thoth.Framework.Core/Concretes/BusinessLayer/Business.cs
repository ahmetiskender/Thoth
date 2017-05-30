using Thoth.Framework.Core.Abstracts.BusinessLayer;
using Thoth.Framework.Core.Abstracts.DataLayer;
using Thoth.Framework.Core.Abstracts.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Thoth.Framework.Core.Concretes.BusinessLayer
{
    public abstract class Business<TEntity, TDatalayer> : IBusiness<TEntity> where TEntity : class, IEntity, new() where TDatalayer : IData<TEntity>, new()
    {
        private readonly TDatalayer _dataLayer;

        public Business()
        {
            _dataLayer = new TDatalayer();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> pregs = null)
        {
            return _dataLayer.GetAll(pregs);
        }

        public List<TEntity> GetAll( DateTime date, Expression<Func<TEntity, bool>> pregs = null)
        {
            return _dataLayer.GetAll(date, pregs);
        }

        public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>> pregs = null)
        {
            return _dataLayer.GetAllQueryable(pregs);
        }

        public TEntity Get(int id)
        {
            return _dataLayer.Get(id);
        }

        public TEntity Get(int id, DateTime date)
        {
            return _dataLayer.Get(id, date);
        }

        public TEntity Add(int userId,TEntity data)
        {
            data.UserIdCreated = userId;
            return _dataLayer.Add(data);
        }

        public TEntity Update(int userId,TEntity data)
        {
            data.UserIdModified = userId;
            return _dataLayer.Update(data);
        }

        public void Delete(int userId, TEntity data)
        {
            data.UserIdModified = userId;
            data.IsDeleted = true;
            _dataLayer.Update(data);
        }



    }
}