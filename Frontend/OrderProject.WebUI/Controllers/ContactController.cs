using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.WebUI.Dtos.ContactDto;
using System.Text;

namespace OrderProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactMessage(CreateContactMessageDto createContactMessageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createContactMessageDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5283/api/Contact", content);
           
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("---- API ERROR ----");
                Console.WriteLine("Status: " + response.StatusCode);
                var apiMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Content: " + apiMessage);
                return View(createContactMessageDto);
            }
            return RedirectToAction("Index");
        }

    }
}
