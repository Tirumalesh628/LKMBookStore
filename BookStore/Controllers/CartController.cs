using BookStore.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CartController : BaseController
    {

        private readonly ICart _cart;

        public CartController(ICart cart)
        {
            _cart = cart;
        }
        public async Task<IActionResult> ViewCart()
        {

            var cartitems = await _cart.GetCart(UserId);
            return View(cartitems);
        }
    }
}
