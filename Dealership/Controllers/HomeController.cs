using Dealership.Models;
using Dealership.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dealership.Controllers
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
