using CoreBusiness;
using Plugins.DataSore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DateStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _db;
        public ProductRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var productFromDb = _db.Products.Find(id);

            if (productFromDb == null)
                return;

            _db.Products.Remove(productFromDb);
            _db.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _db.Products.Find(id);
        }

        public IEnumerable<Product> GetProductsBycategoryId(int categoryId)
        {
            return _db.Products.Where(product => product.categoryId == categoryId).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var productFromDb = _db.Products.Find(product.ProductId);

            productFromDb.Name = product.Name;
            productFromDb.Price = product.Price;
            productFromDb.Quantity = product.Quantity;
            productFromDb.categoryId = product.categoryId;
        }
    }
}
