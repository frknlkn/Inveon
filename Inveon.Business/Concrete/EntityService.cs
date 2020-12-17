using Inveon.Business.Interfaces;
using Inveon.DataAccess.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Inveon.Business.Concrete
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        IUnitOfWork _unitOfWork;
        IRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));


            _repository.Add(entity);
            _unitOfWork.Complete();
        }
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));


            _repository.Remove(entity);
            _unitOfWork.Complete();
        }
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Update(entity);
            _unitOfWork.Complete();
        }
        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

       
    }
}
