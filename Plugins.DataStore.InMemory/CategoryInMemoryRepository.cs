using CoreBusiness;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryInMemoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category{categoryId=1,Name="Beverage",Description="Beverage"},
                new Category{categoryId=2,Name="Bakery",Description="Bakery"},
                new Category{categoryId=3,Name="Meat",Description="Meat"}
            };
        }

        public void AddCategory(Category category)
        {
            if (_categories.Any(item => item.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
                return;

            int maxId = 0;
            if (_categories.Count > 0)
                maxId = _categories.Max(item => item.categoryId);

            category.categoryId = maxId + 1;
            _categories.Add(category);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categories;
        }

        public Category? GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(x => x.categoryId == id);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.categoryId);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public void DeleteCategory(int id)
        {
            var categoryToDelete = GetCategoryById(id);
            _categories.Remove(categoryToDelete);
        }
    }
}