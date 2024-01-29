using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Areas.Admin.ViewComponents.DashboradComponents
{
    public class _AdminDashboardChartRightComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
