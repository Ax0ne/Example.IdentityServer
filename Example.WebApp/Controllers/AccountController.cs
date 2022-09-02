using Microsoft.AspNetCore.Mvc;

namespace Example.WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return Content("<h1>您没有权限</h1>", "text/html; charset=utf-8");
        }
    }
}
