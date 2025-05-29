using Microsoft.AspNetCore.Mvc;

namespace my_mvc_api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}