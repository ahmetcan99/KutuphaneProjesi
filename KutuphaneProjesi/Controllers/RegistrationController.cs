using Microsoft.AspNetCore.Mvc;
using KutuphaneProjesi.Models;

namespace KutuphaneProjesi.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Register()
        {
            UserInfo userInfo = new();
            return View(userInfo);
        }
    }
}
