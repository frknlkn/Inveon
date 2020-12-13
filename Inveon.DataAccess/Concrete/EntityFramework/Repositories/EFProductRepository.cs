using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Inveon.DataAccess.Interfaces;

namespace Inveon.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfProductRepository : Repository<Product>, IProductRepository
    {
        public EfProductRepository(DbContext context) : base(context)
        {
        }

        public Product GetProduct(int id)
        {
            return GetById(id);
        }

        public List<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }
    }
}
