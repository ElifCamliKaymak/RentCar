using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.ViewComponents.CarRentalFilterComponents
{
    public class _CarRentalFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(DateTime v)
        {
            TempData["Value"] = v;
            return View();
        }
    }
}
