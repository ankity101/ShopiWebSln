using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopi.DataAccess.Repository.IRepository
{
    public  interface IRepository<T> where T : class
    {
        //Category
        IEnumerable<T> GetAll();

        //General Syntax for LINQ Operator, FirstOrDefault(u=> u==u.id)
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
