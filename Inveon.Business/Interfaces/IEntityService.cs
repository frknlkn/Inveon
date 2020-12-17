using System;
using System.Linq;
using System.Linq.Expressions;

namespace Inveon.Business.Interfaces
{
    public interface IEntityService<T> : IService where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

    }

}
