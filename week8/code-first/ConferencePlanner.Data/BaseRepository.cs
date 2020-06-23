using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ConferencePlanner.Data
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext context;
        private DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            context.Remove<TEntity>(entity);
        }

        public void Delete(int id)
        {
            var item = context.Find<TEntity>(id);
            context.Remove<TEntity>(item);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
            //return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Find<TEntity>(id);
        }

        public void Insert(TEntity entity)
        {
            context.Add<TEntity>(entity);
        }

        public void Update(TEntity entity)
        {
            context.Update<TEntity>(entity);
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }
}
