using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopi.DataAccess.Data;
using Shopi.DataAccess.Repository.IRepository;

namespace Shopi.DataAccess.Repository
{

     public  class Repository<T> : IRepository<T> where T:class
     {
        private readonly ApplicationDbContext dbContext;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet= dbContext.Set<T>();
        }


        public void Add(T entity)
        {
               dbSet.Add(entity);
        }
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
       
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet.Where(filter);

            return query.FirstOrDefault();
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
           return query.ToList();
        }

     }
}
