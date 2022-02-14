using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public ProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product); 
        }

        IEnumerable<Product> IProductUseCase.GetAllProducts()
        {
            return _productRepository.GetAllProducts();           
        }

        public Product? GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        public IEnumerable<Product> GetProductsById(int Id)
        {
            return _productRepository.GetProductsById(Id);
        }
    }
}
