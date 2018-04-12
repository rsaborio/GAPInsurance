using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> AsEnumerable();
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Expression<Func<T, bool>> expression);
        T GetFirst(Expression<Func<T, bool>> expression);
        T GetById(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
