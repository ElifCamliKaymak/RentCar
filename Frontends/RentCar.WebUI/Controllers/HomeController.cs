using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentCar.ViewModels.CarRentalProcessVms;
using RentCar.ViewModels.LocationVms;

namespace RentCar.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Locations = await GetLocationAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateCarRentalProcessVM model)
        {            
            return RedirectToAction("Index","CarRental", model);
        }

        private async Task<SelectList> GetLocationAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7263/api/Locations");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationVM>>(jsonData);

            return new SelectList(values.Select(x => new SelectListItem
            {
                Value = x.LocationId.ToString(),
                Text = x.Name
            }), "Value", "Text");
        }
    }
}