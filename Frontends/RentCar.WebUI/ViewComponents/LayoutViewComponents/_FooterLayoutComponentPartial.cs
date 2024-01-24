using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.ViewModels.FooterAddressVms;

namespace RentCar.WebUI.ViewComponents.LayoutViewComponents
{
    public class _FooterLayoutComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7263/api/FooterAddresses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddressVM>>(jsonData);                
                return View(values.LastOrDefault());
            }
            return View();
        }
    }
}
