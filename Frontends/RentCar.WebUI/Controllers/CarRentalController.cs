using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.ViewModels.CarPricingVms;
using RentCar.ViewModels.CarRentalProcessVms;
using System.Text;

namespace RentCar.WebUI.Controllers
{
    public class CarRentalController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarRentalController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(CreateCarRentalProcessVM model)
        {            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7263/api/CarRentals/{model.PickUpLocationId}/{model.IsAvailable}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCarPricingWithCarVM>>(jsonData);
                return View(values);
            }
            return View(model);
        }
    }
}
