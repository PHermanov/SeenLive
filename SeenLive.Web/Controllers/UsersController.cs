using Microsoft.AspNetCore.Mvc;

namespace SeenLive.Api.Controllers
{
    public class UsersController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}