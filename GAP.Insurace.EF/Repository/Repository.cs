using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    public class Repository<T> : IRepository<T>, IDisposable where T: class
    {
        private readonly InsuranceContext _context;

        public Repository(InsuranceContext context)
        {
            _context = context;

        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
        }

        public IEnumerable<T> AsEnumerable()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            if (_context.Entry<T>(entity).State == System.Data.Entity.EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }
            _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            Save();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetFirst(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (_context.Entry<T>(entity).State == System.Data.Entity.EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }
            _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
    }
}
