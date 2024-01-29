using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Areas.Admin.ViewComponents.DashboradComponents
{
    public class _AdminDashboardChartMiddleComponentPartial :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
