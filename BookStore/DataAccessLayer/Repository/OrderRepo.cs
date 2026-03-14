using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccessLayer.Repository
{
    public class OrderRepo : IOrder
    {
        private readonly BookStoreDbContext _ordercontext;
        private OrderItems orderItems;
        public OrderRepo(BookStoreDbContext ordercontext, OrderItems orderItems)
        {
            _ordercontext = ordercontext;
            this.orderItems = orderItems;
        }

        public async Task<Order> GetListOfOrders(int? userid)
        {
            return await _ordercontext.orders.Where(u => u.userid == userid).Include(o => o.orderItems).ThenInclude(b => b.Books).FirstOrDefaultAsync();
        }

        public async Task<int> CreateOrder(int? userid)
        {
            if (userid != null)
            {
                Order order = new Order();
                order.userid = userid;

                _ordercontext.orders.Add(order);
                await _ordercontext.SaveChangesAsync();
                return 1;

            }
            else
                return 0;
        }

        public async Task<int> PlaceOrderIndividual(int bookid, int? userid)
        {

            if (bookid != null && userid != null)
            {
                var book = await _ordercontext.book.FindAsync(bookid);
                var order = await _ordercontext.orders.Where(u => u.userid == userid).FirstOrDefaultAsync();
                if (order == null)
                {
                    CreateOrder(userid);
                    order = await _ordercontext.orders.Where(u => u.userid == userid).FirstOrDefaultAsync();
                }

                if (book.QuantityAvailable > 1)
                {
                    book.QuantityAvailable -= 1;
                    _ordercontext.book.Update(book);

                    orderItems.date = DateTime.Now;
                    orderItems.Price = book.Price;
                    orderItems.Status = "order Placed";
                    orderItems.OrderId = order.OrderId;
                    orderItems.Bookid = book.BookID;
                    orderItems.Quantity = 1;
                    _ordercontext.orderItems.Add(orderItems);

                    await _ordercontext.SaveChangesAsync();
                    return 1;

                }
            }


            return 0;

        }





        public async Task<int> PlaceOrderFromcart(int Id, int? userid)
        {

            var cartimes = await _ordercontext.cartItems.Where(c => c.cartid == Id).ToListAsync();
            var order = await _ordercontext.orders.Where(u => u.userid == userid).FirstOrDefaultAsync();

            List<OrderItems> cartorderItems = new List<OrderItems>();
            if (cartimes != null)
            {
                foreach (var cart in cartimes)
                {
                    orderItems = new OrderItems();
                    var book = await _ordercontext.book.FindAsync(cart.bookid);
                    if (book != null)
                    {
                        if (book.QuantityAvailable >= cart.Quanitity)
                        {
                            book.QuantityAvailable -= cart.Quanitity;
                            _ordercontext.book.Update(book);


                            orderItems.date = DateTime.Now;
                            orderItems.Price = cart.Price;
                            orderItems.Status = "Order Placed";
                            orderItems.OrderId = order.OrderId;
                            orderItems.Bookid = cart.bookid;
                            orderItems.Books = cart.book;
                            orderItems.Quantity = cart.Quanitity;
                            //cartorderItems.Add(orderItems);
                            _ordercontext.orderItems.Add(orderItems);
                            _ordercontext.cartItems.Remove(cart);

                        }

                    }

                }

                //_ordercontext.orderItems.AddRangeAsync(cartorderItems);

                await _ordercontext.SaveChangesAsync();

                return 1;

            }

            else { return 0; }



        }
    }
}
