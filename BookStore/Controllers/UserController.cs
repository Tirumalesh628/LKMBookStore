using BookStore.DataAccessLayer;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {

        private readonly IUser _context;
        private readonly ICart _cart;

        public UserController(IUser userOcntext, ICart cart)
        {
            _context = userOcntext;
            _cart = cart;
        }
        [HttpPost]
        public async Task<IActionResult> Login(string UserEmail, string Password)
        {
            var user = await _context.LoginUser(UserEmail, Password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("GetListOfBooks", "Book");

            }
            TempData["ErrorValue"] = "Invalid Credentials try again";
            return RedirectToAction(nameof(LoginPage));
        }

        public async Task<IActionResult> LoginPage()
        {


            ViewBag.Errorvalue = TempData["ErrorValue"];
            return View();
        }
        public async Task<IActionResult> LogOut()
        {

            HttpContext.Session.Clear();

            return RedirectToAction(nameof(LoginPage));
        }

        public async Task<IActionResult> RegisterPage()
        {
            return View();
        }

        public async Task<IActionResult> Register(User user)
        {
            var status = await _context.RegisterUser(user);

            if (status != null)
            {

                ViewBag.Sucess = "Sucess fully Registered redirecting to Log in Page...";
                return RedirectToAction("LogInPage");
            }
            ViewBag.Failure = "Something went Wrong try again..";
            return RedirectToAction("RegisterPage");
        }

    }
}
