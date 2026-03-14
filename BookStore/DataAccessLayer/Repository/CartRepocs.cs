using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccessLayer.Repository
{
    public class CartRepocs : ICart
    {
        private readonly BookStoreDbContext _context;


        public CartRepocs(BookStoreDbContext context)
        {
            _context = context;

        }
        public async Task<int> Addcart(int Id)
        {
            if (Id != null)
            {
                Cart cart = new Cart();
                cart.UserId = Id;

                _context.cart.Add(cart);
                await _context.SaveChangesAsync();
                return 1;
            }
            else return 0;

        }

        public async Task<Cart> GetCart(int? UserID)
        {
            var cart = await _context.cart.Where(u => u.UserId == UserID).Include(u => u.CartItems).ThenInclude(b => b.book).FirstOrDefaultAsync();
            if (cart != null)
                cart.TotalPrice = (double)cart.CartItems.Sum(c => c.Price);

            _context.cart.Update(cart);

            await _context.SaveChangesAsync();
            return cart;


        }

        public async Task<int> GetCartId(int? UserID)
        {
            return await _context.cart.Where(u => u.UserId == UserID).Select(c => c.CartId).FirstOrDefaultAsync();
        }
    }
}
