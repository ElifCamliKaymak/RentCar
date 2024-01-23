using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentCar.ViewModels.LocationVms;
using RentCar.ViewModels.ReservationVms;
using System.Text;

namespace RentCar.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Rezervasyon Formu";
            ViewBag.Locations = await GetLocationAsync();
            ViewBag.CarId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationVM createReservationVM)
        {
            var jsonData = JsonConvert.SerializeObject(createReservationVM);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsync("https://localhost:7263/api/Reservations", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
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
