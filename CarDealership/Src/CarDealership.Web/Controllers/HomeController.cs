using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
    }
}
