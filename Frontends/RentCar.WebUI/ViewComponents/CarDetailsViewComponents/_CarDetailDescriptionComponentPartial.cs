using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.ViewComponents.CarDetailsViewComponents
{
    public class _CarDetailDescriptionComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
