using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.ViewModels.BlogVms;
using RentCar.ViewModels.TagCloudVms;

namespace RentCar.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCloudTagByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsCloudTagByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7263/api/TagClouds/GetTagCloudByBlogIdList/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetTagCloudByBlogIdVM>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
