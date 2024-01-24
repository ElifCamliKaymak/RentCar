using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.ViewModels.StatisticsVms;

namespace RentCar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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

            var responseMessageAuthorCount = await client.GetAsync("https://localhost:7263/api/Statistics/GetAuthorCount");
            if (responseMessageAuthorCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageAuthorCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.AuthorCount = values.AuthorCount;
            };

            var responseMessageBlogCount = await client.GetAsync("https://localhost:7263/api/Statistics/GetBlogCount");
            if (responseMessageBlogCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageBlogCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.BlogCount = values.BlogCount;
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

            var responseMessageAverageRentPriceForWeekly = await client.GetAsync("https://localhost:7263/api/Statistics/GetAverageRentPriceForWeekly");
            if (responseMessageAverageRentPriceForWeekly.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageAverageRentPriceForWeekly.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.AverageRentPriceForWeekly = values.AveragePriceForWeekly;
            };

            var responseMessageAverageRentPriceForMonthly = await client.GetAsync("https://localhost:7263/api/Statistics/GetAverageRentPriceForMonthly");
            if (responseMessageAverageRentPriceForMonthly.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageAverageRentPriceForMonthly.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.AverageRentPriceForMonthly = values.AveragePriceForMonthly;
            };

            var responseMessageCarCountByTransmissionIsAuto = await client.GetAsync("https://localhost:7263/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessageCarCountByTransmissionIsAuto.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageCarCountByTransmissionIsAuto.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.CarCountByTransmissionIsAuto = values.CarCountByTransmissionIsAuto;
            };

            var responseMessageBrandNameByMaximumCar = await client.GetAsync("https://localhost:7263/api/Statistics/GetBrandNameByMaximumCar");
            if (responseMessageBrandNameByMaximumCar.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageBrandNameByMaximumCar.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.BrandNameByMaximumCar = value.BrandNameByMaximumCar;
                ViewBag.BrandCountByMaximumCar = value.BrandCountByMaximumCar;
            };

            var responseMessageBlogTitleByMaximumBlogComment = await client.GetAsync("https://localhost:7263/api/Statistics/GetBlogTitleByMaximumBlogComment");
            if (responseMessageBlogTitleByMaximumBlogComment.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageBlogTitleByMaximumBlogComment.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.BlogTitleByMaximumBlogComment = values.BlogTitleByMaximumBlogComment;
                ViewBag.BlogCountByMaximumBlogComment = values.BlogCountByMaximumBlogComment;
            };

            var responseMessageCarCountByKmSmallerThen1000 = await client.GetAsync("https://localhost:7263/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseMessageCarCountByKmSmallerThen1000.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageCarCountByKmSmallerThen1000.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.CarCountByKmSmallerThen1000 = values.CarCountByKmSmallerThen1000;
            };

            var responseMessageCarCountByFuelGasolineOrDiesel = await client.GetAsync("https://localhost:7263/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessageCarCountByFuelGasolineOrDiesel.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageCarCountByFuelGasolineOrDiesel.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.CarCountByFuelGasolineOrDiesel = values.CarCountByFuelGasolineOrDiesel;
            };

            var responseMessageCarCountByFuelElectric = await client.GetAsync("https://localhost:7263/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessageCarCountByFuelElectric.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageCarCountByFuelElectric.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.CarCountByFuelElectric = values.CarCountByFuelElectric;
            };            

            var responseMessageCarBrandAndModelByRentPriceDailyMax = await client.GetAsync("https://localhost:7263/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessageCarBrandAndModelByRentPriceDailyMax.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageCarBrandAndModelByRentPriceDailyMax.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.CarBrandAndModelByRentPriceDailyMax = values.CarBrandAndModelByRentPriceDailyMax;
            };
            
            var responseMessageCarBrandAndModelByRentPriceDailyMin = await client.GetAsync("https://localhost:7263/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessageCarBrandAndModelByRentPriceDailyMin.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageCarBrandAndModelByRentPriceDailyMin.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticVM>(jsonData);
                ViewBag.CarBrandAndModelByRentPriceDailyMin = values.CarBrandAndModelByRentPriceDailyMin;
            };

            return View();
        }
    }
}
