using Microsoft.AspNetCore.Mvc;

namespace Dealership.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Ошибка 404, такой страницы не существует!";
                    break;
            }
            return View("ErrorPage");
        }
    }
}
