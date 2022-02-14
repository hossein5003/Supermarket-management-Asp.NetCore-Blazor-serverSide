using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductInMemoryRepository()
        {
            _products = new List<Product>()
            {
                new Product() { Id = 1, CategoryId = 1 , Name="Iced Tea",Quantity=100,Price=1.99},
                new Product() { Id = 2, CategoryId = 1 , Name="Canada Dry",Quantity=200,Price=1.99},
                new Product() { Id = 3, CategoryId = 2 , Name="Whole Wheat Bread",Quantity=300,Price=1.50},
                new Product() { Id = 4, CategoryId = 2 , Name="White Bread",Quantity=300,Price=1.50}
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            if (_products.Any(item => item.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
                return;

            int maxId = 0;
            if (_products.Count > 0)
                maxId = _products.Max(item => item.Id);

            product.CategoryId = maxId + 1;
            _products.Add(product);
        }

        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(product => product.CategoryId == id); 
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.Id);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;              
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }
        }

        public void DeleteProduct(int id)
        {
            _products.Remove(_products.FirstOrDefault(product => product.CategoryId == id));
        }

        public IEnumerable<Product> GetProductsById(int Id)
        {
            return _products.Where(product=>product.CategoryId == Id);
        }
    }
}
