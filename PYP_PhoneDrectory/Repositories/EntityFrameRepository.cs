using Microsoft.EntityFrameworkCore;
using PYP_PhoneDrectory.Abstractions.Repositories;
using PYP_PhoneDrectory.DAL;
using PYP_PhoneDrectory.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDrectory.Repositories
{
    public class EntityFrameRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly Context _context;

        public EntityFrameRepository(Context context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public bool Add(T entity)
        {
           var a = Table.Add(entity);
            _context.SaveChanges();
            return a != null;

        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public T Get(Expression<Func<T, bool>> filter=null)
        {
            if(filter == null)
            {
               return Table.FirstOrDefault();
            }
            return Table.FirstOrDefault(filter);
        }

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public bool Update(int Id,T entity)
        {
            var dbEntity = Get();
            dbEntity = entity;
            _context.Update(dbEntity);
            _context.SaveChanges();
            return dbEntity != null;
        }
    }
}
