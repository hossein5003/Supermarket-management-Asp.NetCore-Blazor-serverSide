using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCaseInterfaces
{
    public interface IProductUseCase
    {
        public IEnumerable<Product> GetAllProducts();
        public void AddProduct(Product product);
        public Product? GetProductById(int id);
        public void DeleteProduct(int id);
        public void UpdateProduct(Product product);
        public IEnumerable<Product> GetProductsBycategoryId(int categoryId);
    }
}
