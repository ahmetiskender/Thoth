using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Teos.Net.Papers.Framework.Core.Entities;

namespace Teos.Net.Papers.Framework.Core.DataAccess.EntityFramework
{
    public abstract class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
    {
        private TContext _context;
        private IDbSet<TEntity> _dbset;

        public EfEntityRepositoryBase()
        {
            _context = new TContext();
            _dbset = _context.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
                return _context.Set<TEntity>().Where(x => x.IsDeleted == false && x.IsVersioned == false).ToList();
            
        }

        public List<TEntity> GetAll(DateTime date)
        {
                List<TEntity> list = _context.Set<TEntity>().Where(x => x.IsDeleted == false && x.IsVersioned == false).ToList();
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

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> pregs)
        {
                return _context.Set<TEntity>().Where(pregs).Where(x => x.IsDeleted == false && x.IsVersioned == false).ToList();            

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> pregs, DateTime date)
        {
            using (var context = new TContext())
            {
                List<TEntity> list = context.Set<TEntity>().Where( pregs).Where(x => x.IsDeleted == false && x.IsVersioned == false).ToList();
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
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
                return _context.Set<TEntity>().Where(x => x.IsDeleted == false && x.IsVersioned == false);            
        }

        public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>> pregs)
        {
                return _context.Set<TEntity>().Where( pregs).Where(x => x.IsDeleted == false && x.IsVersioned == false);            
        }

        public TEntity Get(int id)
        {
                return _context.Set<TEntity>().Where(x => x.IsDeleted == false && x.IsVersioned == false && x.Id == id).FirstOrDefault();
        }

        public TEntity Get(int id, DateTime date)
        {
                List<TEntity> list = _context.Set<TEntity>().Where(x => (x.Id == id || x.ParentId == id) && x.ModifiedAt <= date).ToList();

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

        public TEntity Add(TEntity data)
        {
                var addedEntity = _context.Entry(data);
                addedEntity.State = EntityState.Added;
            _context.SaveChanges();

                return addedEntity.Entity;
            
        }

        public TEntity Update(TEntity data)
        {
                var updatedEntity = _context.Entry(data);
                updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();

                return updatedEntity.Entity;
        }

        public void Delete(TEntity data)
        {
                var deletedEntity = _context.Entry(data);
                deletedEntity.State = EntityState.Deleted;
                _context.SaveChanges();
        }


    }
}
