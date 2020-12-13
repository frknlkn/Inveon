using System.Linq;

namespace Inveon.Business.Interfaces
{
    public interface IEntityService<T> : IService where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
    }

}
