using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.WebUI.Dtos.BookingDto;
using OrderProject.WebUI.Dtos.ProductDto;
using System.Text;

namespace OrderProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(Create2BookingDto createBookingDto)
        {
         
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createBookingDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5283/api/Booking", content);

         
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("---- API ERROR ----");
                Console.WriteLine("Status: " + response.StatusCode);

                var apiMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Content: " + apiMessage);

                return View(createBookingDto);
            }

            return RedirectToAction("Index");
        }
    }
}
