using BookStore.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Viewcomponets
{
    public class CategoryViewcomponent : ViewComponent
    {
        private readonly Icategories _category;

        public CategoryViewcomponent(Icategories context)
        {
            _category = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var category = await _category.categories();
            return View(category);
        }


    }
}
