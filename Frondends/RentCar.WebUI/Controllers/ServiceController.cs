using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
