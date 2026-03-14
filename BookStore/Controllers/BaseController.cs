using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.Controllers
{
    public class BaseController : Controller
    {
        protected int? UserId
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (UserId == null)
            {
                context.Result = RedirectToAction("LoginPage", "User");
            }
            base.OnActionExecuting(context);
        }

    }
}
