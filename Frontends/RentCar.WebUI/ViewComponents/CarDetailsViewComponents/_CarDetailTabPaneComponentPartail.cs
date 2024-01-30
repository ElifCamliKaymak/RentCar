using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.ViewComponents.CarDetailsViewComponents
{
    public class _CarDetailTabPaneComponentPartail :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailTabPaneComponentPartail(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
