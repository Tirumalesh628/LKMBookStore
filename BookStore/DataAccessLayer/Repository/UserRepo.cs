using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccessLayer.Repository
{
    public class UserRepo : IUser
    {
        private readonly BookStoreDbContext _context;
        private readonly ICart _cart;
        private readonly IOrder _order;
        int status = 0;
        public UserRepo(BookStoreDbContext context, ICart cart, IOrder order)
        {
            _context = context;
            _cart = cart;
            _order = order;

        }

        public async Task<int> DelateUser(int id)
        {
            var user = await UserById(id);
            if (user != null)
            {
                _context.users.Remove(user);
                await _context.SaveChangesAsync();
                status = 1;
            }

            return status;
        }

        public async Task<User> LoginUser(string Email, string Password)
        {
            User user = new();
            if (Email != null || Password != null)
            {
                user = await _context.users.Where(u => u.UserEmail == Email && u.Password == Password).FirstOrDefaultAsync();
            }
            return user;
        }

        public async Task<int> RegisterUser(User user)
        {
            if (user != null)
            {



                //user.cart=_cart.Addcart

                _context.users.Add(user);
                await _context.SaveChangesAsync();
                int Userid = await _context.users.Where(u => u.UserEmail == user.UserEmail && u.Password == user.Password).Select(s => s.UserId).FirstOrDefaultAsync();
                status = await _cart.Addcart(Userid);
                status = await _order.CreateOrder(Userid);





            }
            return status;
        }

        public async Task<int> UpdateUser(User user)
        {
            if (user != null)
            {
                _context.users.Update(user);
                await _context.SaveChangesAsync();
                status = 1;
            }
            return status;
        }

        public async Task<User> UserById(int id)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
