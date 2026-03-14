using BookStore.DataAccessLayer;
using BookStore.DataAccessLayer.Repository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BookStoreDbContext>(Options =>
            
                Options.UseSqlServer(builder.Configuration.GetConnectionString("BookStore"))
            );
            builder.Services.AddScoped<IBookRepo, BookRepo>();
            builder.Services.AddScoped<Icategories,CategoryRepo>();
            builder.Services.AddScoped<IUser, UserRepo>();
            builder.Services.AddScoped<ICart, CartRepocs>();
            builder.Services.AddScoped<IcartItems, CartItemsRepo>();
            builder.Services.AddScoped<IOrder, OrderRepo>();
            builder.Services.AddScoped<OrderItems>();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(
                Options =>
                {
                    Options.IdleTimeout = TimeSpan.FromMinutes(10);
                    Options.Cookie.HttpOnly = true;
                    Options.Cookie.IsEssential = true;
                }
            );
            var app = builder.Build();
            //builder.Services.AddHttpContextAccessor();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseExceptionHandler("/Error");

            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=LoginPage}/{id?}");
            //app.MapGet("/Getbooks", ([FromServices] IBookRepo b) => b.GetListOfBooks());
            
            app.Run();
        }
    }
}
