using ECommerceAPI.DataContext;
using ECommerceAPI.Models;
using ECommerceAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Category> GetAllCategorys()
        {
            return _context.Category.ToList();
        }
        public Category GetCategoryById(int id)
        {
            return _context.Category.FirstOrDefault(p => p.Id == id);
        }
        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Category.Add(category);
            _context.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var category = _context.Category.Find(id);
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
    }
}
