using ECommerceAPI.Models;

namespace ECommerceAPI.Repository.Interface
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void DeleteCategory(int id);
        List<Category> GetAllCategorys();
        Category GetCategoryById(int id);
        void UpdateCategory(Category category);
    }
}
