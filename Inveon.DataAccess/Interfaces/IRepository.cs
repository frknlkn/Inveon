using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Inveon.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(Func<T, bool> predicate = null);
        T GetById(int id);
        T GetByGuid(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Save();
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
