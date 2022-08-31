using Microsoft.AspNetCore.Mvc;

namespace KutuphaneProjesi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
