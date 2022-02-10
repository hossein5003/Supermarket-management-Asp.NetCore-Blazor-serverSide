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
    public class CategoryUseCase : ICategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository= categoryRepository;
        }

        public void AddCategory(Category category)
        {
           _categoryRepository.AddCategory(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }

        public Category? GetCategoryById(int id)
        {
           return _categoryRepository.GetCategoryById(id); 
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }
    }
}
