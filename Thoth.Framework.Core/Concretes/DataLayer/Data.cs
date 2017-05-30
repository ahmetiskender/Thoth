using Thoth.Framework.Core.Abstracts.DataLayer;
using Thoth.Framework.Core.Abstracts.EntityLayer;
using Thoth.Framework.Core.Aspects.CacheAspects;
using Thoth.Framework.Core.CrossCuttingConcern.Transaction.ManageHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Thoth.Framework.Core.Utilities.Helpers;

namespace Thoth.Framework.Core.Concretes.DataLayer
{
    public abstract class Data<TEntity, TContext> :  IData<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        private TContext _context;
        private IDbSet<TEntity> _dbset;

        public Data()
        {
            _context = new TContext();
            _dbset = _context.Set<TEntity>();
        }

       // [CacheAspect]
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> pregs = null)
        {
            
            if (pregs != null)
                return  _dbset.Where(pregs).Where(x => x.IsDeleted == false && x.IsVersioned == false).ToList();
            else
                return _dbset.Where(x => x.IsDeleted == false && x.IsVersioned == false).ToList();

        }

       // [CacheAspect]
        public List<TEntity> GetAll(DateTime date, Expression<Func<TEntity, bool>> pregs = null)
        {
            List<TEntity> list = new List<TEntity>();

            if (pregs != null)
                list = _dbset.Where(pregs).Where(x => x.IsDeleted == false && x.IsVersioned == false).ToList();
            else
                list = _dbset.Where(pregs).Where(x => x.IsDeleted == false && x.IsVersioned == false).ToList();

            List<TEntity> returnList = new List<TEntity>();

            foreach (TEntity i in list)
            {
                TEntity item = Get(i.Id, date);
                if (item != null)
                {
                    returnList.Add(item);
                }
            }

            return returnList;
        }

        //[CacheAspect]
        public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>> pregs = null)
        {
            if (pregs != null)
                return _dbset.Where(pregs).Where(x => x.IsDeleted == false && x.IsVersioned == false);
            else
                return _dbset.Where(x => x.IsDeleted == false && x.IsVersioned == false);
        }

       // [CacheAspect]
        public TEntity Get(int id)
        {
            return _dbset.Where(x => x.IsDeleted == false && x.IsVersioned == false && x.Id == id).FirstOrDefault();
        }

        //[CacheAspect]
        public TEntity Get(int id, DateTime date)
        {
            List<TEntity> list = _dbset.Where(x => (x.Id == id /*|| x.ParentId == id*/) && x.ModifiedAt <= date).ToList();

            if (list.Count > 0)
            {
                TEntity item = list.OrderByDescending(x => x.ModifiedAt).ToList().First();
                if (item.Id == id)
                {
                    if (item.IsDeleted)
                    {
                        return null;
                    }
                }
                return item;
            }
            else
            {
                return null;
            }
        }

       // [CacheRemoveAspect]
        public TEntity Add(TEntity data)
        {
            data.PrepareForInsert();
            var addedEntity = _context.Entry(data);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();

            return addedEntity.Entity;
        }

      //  [CacheRemoveAspect]
        public TEntity Update(TEntity data)
        {
            data.PrepareForUpdate();
            var updatedEntity = _context.Entry(data);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();

            return updatedEntity.Entity;
        }

       // [CacheRemoveAspect]
        public void Delete(TEntity data)
        {
            data.PrepareForDelete();
            var deletedEntity = _context.Entry(data);
            deletedEntity.State = EntityState.Modified;
            //deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

    }
}