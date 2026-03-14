using BookStore.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrder orderrepo;

        public OrderController(IOrder order)
        {
            orderrepo = order;
        }

        public async Task<IActionResult> GetListOFOrders()
        {
            var orders = await orderrepo.GetListOfOrders(UserId);

            return View(orders);
        }

        public async Task<IActionResult> PlaceOrderIndividual(int BookId)
        {
            var status = await orderrepo.PlaceOrderIndividual(BookId, UserId);

            if (status == 0)
            {
                return View(status);
            }
            else
            {
                return RedirectToAction("GetListOFOrders");
            }

        }

        public async Task<IActionResult> PlaceOrderFromcart(int ID)
        {

            var status = await orderrepo.PlaceOrderFromcart(ID, UserId);
            if (status == 0)
            {
                return RedirectToAction("Cart", "cartItems");
            }
            else
            {
                return RedirectToAction("GetListOFOrders");
            }
        }
    }
}
