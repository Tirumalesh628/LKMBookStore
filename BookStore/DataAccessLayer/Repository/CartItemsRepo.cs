using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccessLayer.Repository
{
    public class CartItemsRepo : IcartItems
    {
        private readonly BookStoreDbContext _context;
        private readonly ICart cart;
        int status = 0;
        int? Userid;

        public CartItemsRepo(BookStoreDbContext context, ICart cart)
        {
            _context = context;
            this.cart = cart;

        }
        public async Task<int> AddCartItems(int id, int? userid)
        {
            if (id > 0)
            {

                var cartitem = await _context.cartItems.Include(b => b.cart).ThenInclude(b => b.CartItems).ThenInclude(b => b.book).Where(x => x.cart.UserId == id).FirstOrDefaultAsync();

                if (cartitem != null)
                {

                    cartitem.Quanitity += 1;
                    cartitem.Price = cartitem.Quanitity * cartitem.book.Price;

                    _context.cartItems.Update(cartitem);
                }
                else
                {
                    CartItems cartItems = new CartItems();

                    cartItems.cartid = await cart.GetCartId(userid);
                    cartItems.bookid = id;
                    cartItems.Quanitity = 1;
                    cartItems.Price = _context.book.Where(c => c.BookID == id).Select(s => s.Price).Single();
                    await _context.cartItems.AddAsync(cartItems);
                }
                await _context.SaveChangesAsync();
                status = 1;
            }

            return status;
        }

        public async Task Add(int BookId, int? UserId)
        {
            if (BookId > 0)
            {
                var cartitems = await _context.cartItems.Include(c => c.cart).ThenInclude(b => b.CartItems).ThenInclude(c => c.book).Where(x => x.cart.UserId == UserId && x.book.BookID == BookId).FirstOrDefaultAsync();
                cartitems.Quanitity += 1;
                cartitems.Price = (double)(cartitems.Quanitity * cartitems.book.Price);
                _context.cartItems.Update(cartitems);
                await _context.SaveChangesAsync();

            }

        }
        public async Task Remove(int BookId, int? UserId)
        {
            if (BookId > 0)
            {
                var cartitems = await _context.cartItems.Include(c => c.cart).ThenInclude(b => b.CartItems).ThenInclude(b => b.book).Where(x => x.cart.UserId == UserId && x.book.BookID == BookId).FirstOrDefaultAsync();
                if (cartitems.Quanitity <= 1 && cartitems != null)
                {

                    _context.cartItems.Remove(cartitems);
                }
                else
                {
                    cartitems.Quanitity -= 1;
                    cartitems.Price = cartitems.Quanitity * cartitems.book.Price;
                    _context.cartItems.Update(cartitems);
                }
                await _context.SaveChangesAsync();

            }

        }

        public async Task<List<CartItems>> ViewCart(int? userid)
        {

            return await _context.cartItems.Include(c => c.book).Include(b => b.cart).Where(x => x.cart.UserId == userid).ToListAsync();
        }


    }
}
