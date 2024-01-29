using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.ViewModels.StatisticsVms;

namespace RentCar.WebUI.Areas.Admin.ViewComponents.DashboradComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessageCarCount = await client.GetAsync("https://localhost:7263/api/Statistics/GetCarCount");
            if (responseMessageCarCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageCarCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.CarCount = values.CarCount;
            };

            var responseMessageLocationCount = await client.GetAsync("https://localhost:7263/api/Statistics/GetLocationCount");
            if (responseMessageLocationCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageLocationCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.LocationCount = values.LocationCount;
            };

            var responseMessageBrandCount = await client.GetAsync("https://localhost:7263/api/Statistics/GetBrandCount");
            if (responseMessageBrandCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageBrandCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.BrandCount = values.BrandCount;
            };

            var responseMessageAverageRentPriceForDaily = await client.GetAsync("https://localhost:7263/api/Statistics/GetAverageRentPriceForDaily");
            if (responseMessageAverageRentPriceForDaily.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageAverageRentPriceForDaily.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.AverageRentPriceForDaily = values.AveragePriceForDaily;
            };

            return View(); 
        }
    }
}
