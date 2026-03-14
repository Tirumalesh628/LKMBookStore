using BookStore.Models;
using Microsoft.EntityFrameworkCore;


namespace BookStore.DataAccessLayer.Repository
{
    public class BookStoreDbContext : DbContext
    {


        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> Options) : base(Options)
        {

        }

        public DbSet<Book> book { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<OrderItems> orderItems { get; set; }
        public DbSet<User> users { get; set; }

        public DbSet<CartItems> cartItems { get; set; }

    }
}
