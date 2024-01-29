using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.ViewModels.CarVms;

namespace RentCar.WebUI.ViewComponents.CarDetailsViewComponents
{
    public class _CarDetailsMainCarFeatureComponentPartial :ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailsMainCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.CarId = id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7263/api/Cars/{id}");
			if( responseMessage.IsSuccessStatusCode) 
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultCarWithBrandsVM>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
