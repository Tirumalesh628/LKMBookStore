using BookStore.Models;
namespace BookStore.DataAccessLayer
{
    public interface IBookRepo
    {

        public Task<List<Book>> GetListOfBooks();

        public Task<List<Book>> GetListOfBooksById(int? Id);

        public Task<List<Book>> GetListOfBooksByCategory(int Id);

        public Task<int> AddBook(Book book);

        public Task<int> UpdateBook(Book book);

        public Task<int> DeleteBook(int Id);

    }
}
