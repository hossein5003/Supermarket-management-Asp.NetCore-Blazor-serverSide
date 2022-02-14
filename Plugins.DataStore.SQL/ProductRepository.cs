using CoreBusiness;
using Microsoft.EntityFrameworkCore;
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
            return _db.Products.Include(x=>x.Category).ToList();
        }

        public Product? GetProductById(int id)
        {
            return _db.Products.Find(id);
        }

        public IEnumerable<Product> GetProductsById(int Id)
        {
            return _db.Products.Where(product => product.CategoryId == Id).Include(x=>x.Category).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var productFromDb = _db.Products.Find(product.Id);

            productFromDb.Name = product.Name;
            productFromDb.Price = product.Price;
            productFromDb.Quantity = product.Quantity;
            productFromDb.CategoryId = product.CategoryId;

            _db.SaveChanges();
        }
    }
}
