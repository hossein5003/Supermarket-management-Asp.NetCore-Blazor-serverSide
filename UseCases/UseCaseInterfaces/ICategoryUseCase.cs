using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCaseInterfaces
{
    public  interface ICategoryUseCase
    {
        public IEnumerable<Category> GetCategories();
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public Category GetCategoryById(int id);
        public void DeleteCategory(int id);
    }
}
