using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.DtoLayer.Booking;
using OrderProject.WebUI.Dtos.BookingDto;
using OrderProject.WebUI.Dtos.ProductDto;
using System.Text;

namespace OrderProject.WebUI.Controllers
{
    [AllowAnonymous]
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
            if (!ModelState.IsValid)
            {
                return View("Index", createBookingDto);
            }

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

                  return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
