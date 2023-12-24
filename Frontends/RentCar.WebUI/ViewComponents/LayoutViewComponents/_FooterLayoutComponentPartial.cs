using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.ViewComponents.LayoutViewComponents
{
    public class _FooterLayoutComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
