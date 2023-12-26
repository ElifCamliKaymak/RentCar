using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Areas.Admin.ViewComponents.LayoutViewComponents
{
    public class _AdminSidebarLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
