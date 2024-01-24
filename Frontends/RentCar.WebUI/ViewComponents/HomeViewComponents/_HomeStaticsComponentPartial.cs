using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.ViewModels.StatisticsVms;

namespace RentCar.WebUI.ViewComponents.HomeViewComponents
{
    public class _HomeStaticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeStaticsComponentPartial(IHttpClientFactory httpClientFactory)
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

            var responseMessageCarCountByFuelElectric = await client.GetAsync("https://localhost:7263/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessageCarCountByFuelElectric.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageCarCountByFuelElectric.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.CarCountByFuelElectric = values.CarCountByFuelElectric;
            };
            return View();
        }
    }
}
