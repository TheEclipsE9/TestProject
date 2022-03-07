using Microsoft.AspNetCore.Mvc;

namespace TestProjectWeb.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
