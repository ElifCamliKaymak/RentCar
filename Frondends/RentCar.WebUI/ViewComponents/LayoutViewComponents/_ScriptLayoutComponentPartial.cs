using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.ViewComponents.LayoutViewComponents
{
    public class _ScriptLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
