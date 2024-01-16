using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.ViewComponents.CarRentalFilterComponents
{
    public class _CarRentalFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
