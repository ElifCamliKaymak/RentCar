using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Areas.Admin.ViewComponents.LayoutViewComponents
{
    public class _AdminScriptLayoutComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
