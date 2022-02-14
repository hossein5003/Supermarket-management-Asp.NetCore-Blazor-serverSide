using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public void AddProduct(Product product);
        public Product? GetProductById(int id);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
        public IEnumerable<Product> GetProductsById(int Id);
    }
}
