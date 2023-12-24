using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.ViewComponents.HomeViewComponents
{
    public class _HomeStaticsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
