using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.ViewComponents.LayoutViewComponents
{
    public class _MainCoverLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
