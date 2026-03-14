using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccessLayer.Repository
{
    public class CategoryRepo : Icategories
    {
        private readonly BookStoreDbContext _context;
        private int status = 0;
        public CategoryRepo(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCategory(Category category)
        {
            if (category != null)
            {
                _context.categories.Add(category);
                await _context.SaveChangesAsync();
                status = 1;
            }
            return status;
        }

        public async Task<List<Category>> categories()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<int> DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);
            if (category != null)
            {
                _context.categories.Remove(category);
                await _context.SaveChangesAsync();
                status = 1;
            }

            return status;
        }

        public async Task<Category> GetCategoryById(int Id)
        {
            return await _context.categories.FirstOrDefaultAsync(c => c.CategoryId == Id);
        }


    }
}
