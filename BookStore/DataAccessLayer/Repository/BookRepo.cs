using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccessLayer.Repository
{
    public class BookRepo : IBookRepo
    {

        private BookStoreDbContext _contaxt;
        int status = 0;
        public BookRepo(BookStoreDbContext context)
        {
            _contaxt = context;
        }
        public async Task<int> AddBook(Book book)
        {
            try
            {

                if (book != null)
                {
                    if (book.imagefile != null)
                    {
                        var Fname = Guid.NewGuid().ToString() + Path.GetExtension(book.imagefile.FileName);
                        var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/bookcoverphoto", Fname);
                        using (var fs = new FileStream(file, FileMode.Create))
                        {
                            await book.imagefile.CopyToAsync(fs);
                        }
                        book.ImagePath = "/images/Bookcoverphoto/" + Fname;
                    }
                    Category cat = await _contaxt.categories.FirstOrDefaultAsync(c => c.CategoryId == book.categoryId);
                    book.category = cat;
                    await _contaxt.book.AddAsync(book);
                    await _contaxt.SaveChangesAsync();
                    status = 1;
                }
            }
            catch (Exception ex)
            {
                status = 0;
            }

            return status;

        }

        public async Task<int> DeleteBook(int Id)
        {
            try
            {
                if (Id != null)
                {
                    var book = await GetListOfBooksById(Id);

                    if (book != null)
                    {

                        _contaxt.book.Remove(book[0]);
                        await _contaxt.SaveChangesAsync();
                        status = 1;
                    }
                }

            }
            catch
            {
                status = 0;
            }

            return status;
        }

        public async Task<List<Book>> GetListOfBooks()
        {
            List<Book> books = new();
            try
            {
                books = await _contaxt.book.ToListAsync();
            }
            catch
            {

            }
            return books;
        }

        public async Task<List<Book>> GetListOfBooksByCategory(int Id)
        {

            return await _contaxt.book.Where(b => b.categoryId == Id).ToListAsync();
        }

        public async Task<List<Book>> GetListOfBooksById(int? Id)
        {
            return await _contaxt.book.Where(b => b.BookID == Id).ToListAsync();
        }

        public async Task<int> UpdateBook(Book book)
        {
            try
            {
                _contaxt.book.Update(book);
                await _contaxt.SaveChangesAsync();
                status = 1;
            }
            catch (Exception ex)
            {
                status = 0;
            }
            return status;

        }
    }
}
