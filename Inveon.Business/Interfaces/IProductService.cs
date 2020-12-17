using System.Collections.Generic;
using Inveon.DataAccess.Concrete.EntityFramework;

namespace Inveon.Business.Interfaces
{
    public interface IProductService : IEntityService<Product>
    {
        void AddProduct(Product product);
        /// <summary>
        /// Get single product details
        /// </summary>
        /// <param name="id">productId</param>
        Product GetProduct(int id);

        /// <summary>
        /// Get All Products
        /// </summary>
        List<Product> GetAllProducts();

    }

}
