using PYP_PhoneDrectory.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDrectory.Abstractions.Repositories
{
    public interface IRepository<T> where T : class,IEntity
    {
        T Get(Expression<Func<T, bool>> filter=null);
        List<T> GetAll();
        bool Add(T entity);
        bool Update(int id,T entity);
        bool Delete(T entity);
    }
}
