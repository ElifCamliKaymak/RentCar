using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.ViewComponents.CarDetailsViewComponents
{
    public class _CarDetailsCommentsByCarIdComponentPartail : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
