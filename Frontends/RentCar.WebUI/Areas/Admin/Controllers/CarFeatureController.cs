using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.ViewModels.CarFeatureVms;
using System.Text;

namespace RentCar.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CarFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7263/api/CarFeatures/CarFeaturesListByCar/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdVM>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CarDetail(List<UpdateCarFeatureVM> features)
        {
            foreach (var feature in features)
            {
                var jsonData = JsonConvert.SerializeObject(feature);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.PutAsync($"https://localhost:7263/api/CarFeatures/", content);

                if (responseMessage.IsSuccessStatusCode)
                    continue;                
            }
            return RedirectToAction("Index", "Car");
        }
    }
}
