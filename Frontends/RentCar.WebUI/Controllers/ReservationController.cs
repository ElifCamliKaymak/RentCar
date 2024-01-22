using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Rezervasyon Formu";
            return View();
        }
    }
}
