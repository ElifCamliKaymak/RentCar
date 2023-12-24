using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.ViewModels.ContactVms;
using System.Text;

namespace RentCar.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactVM createContactVM)
        {
            var client = _httpClientFactory.CreateClient();

            createContactVM.sendDate = DateTime.Now;
            var jsonData=JsonConvert.SerializeObject(createContactVM);

            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7263/api/Contacts", content);

            if(responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Default");
            
            return View();
        }
    }
}
