using Shopi.DataAccess.Data;
using Shopi.DataAccess.Repository.IRepository;
using Shopi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.DataAccess.Repository
{
    public  class CategoryRepository : Repository<Category> ,  ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository( ApplicationDbContext dbContext) : base(dbContext ) 
        {
            this.dbContext = dbContext;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Update(Category obj)
        {
            dbContext.Update(obj);
        }
    }
}
