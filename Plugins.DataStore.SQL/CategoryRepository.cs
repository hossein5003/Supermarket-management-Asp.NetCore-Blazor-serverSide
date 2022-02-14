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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _db;
        public CategoryRepository(ApplicationContext db)
        {
            _db = db;
        }
        public void AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
                return;

            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _db.Categories.Include(x => x.Products).ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return _db.Categories.Find(id);
        }

        public void UpdateCategory(Category category)
        {
            var categoryFromDb = _db.Categories.Find(category.Id);

            categoryFromDb.Name = category.Name;
            categoryFromDb.Description = category.Description;
            _db.SaveChanges();
        }
    }
}
