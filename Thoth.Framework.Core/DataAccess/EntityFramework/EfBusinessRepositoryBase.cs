using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Teos.Net.Papers.Framework.Core.Entities;
using Teos.Net.Papers.Framework.Core.CrossCuttingConcern.Transaction.ManageHelper;

namespace Teos.Net.Papers.Framework.Core.DataAccess.EntityFramework
{
    public abstract class EfBusinessRepositoryBase<TEntity, TDatalayer> : ManagerBase,IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TDatalayer : IEntityRepository<TEntity>, new()
    {
        private readonly TDatalayer _dataLayer;

        public EfBusinessRepositoryBase()
        {
            _dataLayer = new TDatalayer();
        }

        public TEntity Get(int id)
        {
            return _dataLayer.Get(id);
        }

        public TEntity Get(int id, DateTime date)
        {
            return _dataLayer.Get(id, date);
        }

        public TEntity Add(TEntity data)
        {
            return _dataLayer.Add(data);
        }

        public TEntity Update(TEntity data)
        {
            return _dataLayer.Update(data);
        }

        public void Delete(TEntity data)
        {
            _dataLayer.Delete(data);
        }

        public List<TEntity> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public List<TEntity> GetAll(DateTime date)
        {
            return _dataLayer.GetAll(date);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> pregs)
        {
            return _dataLayer.GetAll(pregs);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> pregs, DateTime date)
        {
            return _dataLayer.GetAll(pregs, date);
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _dataLayer.GetAllQueryable();
        }

        public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>> pregs)
        {
            return _dataLayer.GetAllQueryable(pregs);
        }

    }
}
