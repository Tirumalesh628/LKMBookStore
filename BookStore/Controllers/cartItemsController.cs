using BookStore.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class cartItemsController : BaseController
    {
        private readonly IcartItems _cart;

        public cartItemsController(IcartItems cart)
        {
            _cart = cart;
        }
        public async Task<IActionResult> AddCartItems(int Id)
        {

            await _cart.AddCartItems(Id, UserId);
            return RedirectToAction("ViewCart", "Cart");
        }

        public async Task<IActionResult> Add(int BookId)
        {


            await _cart.Add(BookId, UserId);
            return RedirectToAction("ViewCart", "Cart");
        }
        public async Task<IActionResult> Remove(int BookId)
        {


            await _cart.Remove(BookId, UserId);
            return RedirectToAction("ViewCart", "Cart");
        }
    }
}
