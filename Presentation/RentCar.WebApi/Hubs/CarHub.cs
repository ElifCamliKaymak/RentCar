using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace RentCar.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageCarCount = await client.GetAsync("https://localhost:7263/api/Statistics/GetCarCount");

            var value = await responseMessageCarCount.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCarCount", value);

        }
    }
}
