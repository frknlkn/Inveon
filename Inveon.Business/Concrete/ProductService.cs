using System;
using Inveon.Business.Interfaces;
using Inveon.DataAccess.Interfaces;
using System.Collections.Generic;
using Inveon.DataAccess.Concrete.EntityFramework;

namespace Inveon.Business.Concrete
{
    public class ProductService : EntityService<Product>, IProductService
    {
        IUnitOfWork _unitOfWork;
        IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
            : base(unitOfWork,productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }


        public void AddProduct(Product product)
        {
            product.RecordDate= DateTime.Now;
            product.UpdateDate= DateTime.Now;
            Add(product);
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetById(id);

        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}
