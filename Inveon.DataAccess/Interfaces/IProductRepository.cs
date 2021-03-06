﻿using System.Collections.Generic;
using Inveon.DataAccess.Concrete.EntityFramework;

namespace Inveon.DataAccess.Interfaces
{
   public interface IProductRepository:IRepository<Product>
    {
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
