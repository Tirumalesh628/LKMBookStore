using BookStore.Models;

namespace BookStore.DataAccessLayer
{
    public interface Icategories
    {
        public Task<List<Category>> categories();
        public Task<Category> GetCategoryById(int Id);

        public Task<int> DeleteCategory(int id);

        public Task<int> AddCategory(Category category);
    }
}
