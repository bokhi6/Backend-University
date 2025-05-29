using Microsoft.AspNetCore.Mvc;

namespace Api_University.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}