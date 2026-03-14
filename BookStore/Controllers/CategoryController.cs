using BookStore.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly Icategories _categoryRepo;
        public CategoryController(Icategories _cat)
        {
            _categoryRepo = _cat;
        }

        public async Task<IActionResult> GetAllcategories()
        {
            var cartogories = await _categoryRepo.categories();
            return View(cartogories);
        }
    }
}
