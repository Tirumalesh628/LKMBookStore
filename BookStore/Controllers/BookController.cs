using BookStore.DataAccessLayer;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : BaseController
    {

        public IBookRepo Bookrepo;

        public BookController(IBookRepo bookrepo)
        {
            Bookrepo = bookrepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetListOfBooks(int? id)
        {
            var books = new List<Book>();
            if (id != null)
            {

                books = await Bookrepo.GetListOfBooksById(id);
            }
            else
            {
                books = await Bookrepo.GetListOfBooks();
            }
            return View(books);
        }


        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        [HttpGet]
        public ActionResult AddBookpage()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]

        public async Task<ActionResult> AddBook(Book book)
        {
            int status = 0;
            try
            {


                if (!ModelState.IsValid)
                {

                    status = await Bookrepo.AddBook(book);

                }

                else
                    status = 0;


            }
            catch
            {
                ViewBag.error = "Some thing went wrong please try again..";
                return RedirectToAction("AddBookpage");
            }
            if (status > 0)
                return RedirectToAction(nameof(GetListOfBooks));
            else
            {
                ViewBag.error = "Some thing went wrong please try again..";
                return RedirectToAction("AddBookpage");
            }
        }


        public ActionResult Edit(int id)
        {

            return View();
        }


        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpGet]
        public async Task<ActionResult> GetListOfBooksByCategory(int Id)
        {
            var bookcat = await Bookrepo.GetListOfBooksByCategory(Id);
            return View("GetListOfBooks", bookcat);
        }

    }
}
