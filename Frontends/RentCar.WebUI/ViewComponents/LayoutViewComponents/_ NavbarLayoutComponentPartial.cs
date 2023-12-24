using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.ViewComponents.LayoutViewComponents
{
    public class _NavbarLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
