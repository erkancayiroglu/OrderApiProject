using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using OrderProject.DtoLayer.OrderDto1;
using OrderProject.EntityLayer.Concrete;



using OrderProject.WebUI.Dtos.SepetDto;
using System.Security.Claims;
using System.Text;

namespace OrderProject.WebUI.Controllers
{

    public class SepetController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public SepetController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            int userId = user.Id;

            var client = _httpClientFactory.CreateClient();

            // SEPETİ GETİR
            var sepetResponse = await client.GetAsync(
                $"http://localhost:5283/api/SepetItem/GetUserSepet/{userId}");

            if (!sepetResponse.IsSuccessStatusCode)
                return View("Error");

            var sepetJson = await sepetResponse.Content.ReadAsStringAsync();
            var sepet = JsonConvert.DeserializeObject<ResultSepetDto>(sepetJson);

            if (sepet == null || sepet.SepetItems.Count == 0)
            {
                ViewBag.Error = "Sepetiniz boş.";
                return RedirectToAction("Index");
            }

            // DTO
            var dto = new CreateUIOrderDto
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                OrderStatus = "Onay Bekleniyor",
                TotalAmount = sepet.TotalAmount,
                OrderBooks = sepet.SepetItems.Select(x => new CreateOrderBookDto
                {
                    ProductId = x.ProductId,
                    Piece = x.Piece,
                    TotalPrice = x.TotalPrice
                }).ToList()
            };

            // API İÇİN JSON
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // *** SİPARİŞİ API'YE GÖNDER ***
            var orderResponse = await client.PostAsync(
                "http://localhost:5283/api/Order/AddOrder", content);

            if (!orderResponse.IsSuccessStatusCode)
            {
                // API'nin döndürdüğü hata metnini al
                var errorContent = await orderResponse.Content.ReadAsStringAsync();

                // Debug için logla (console -> uygulama çıktılarına düşer)
                Console.WriteLine("Order API error: " + errorContent);

                // Hata mesajını View'a geçir
                ViewBag.ApiError = errorContent;

                return View("Error");
            }

            // SEPETİ TEMİZLE
            await client.DeleteAsync($"http://localhost:5283/api/SepetItem/ClearUserSepet/{userId}");

            var responseJson = await orderResponse.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseJson);
            int orderId = result.orderId;

            return RedirectToAction("Sipariş", new { id = orderId });


        }


        public async Task<IActionResult> Sipariş(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(
                $"http://localhost:5283/api/Order/GetDetails/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Sipariş bulunamadı.";
                return View("Error");
            }

            var json = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDetailDto>(json);

            return View(order);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCard(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            int userId = user.Id;

            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsync(
                $"http://localhost:5283/api/SepetItem/AddToCard/{productId}/{userId}",
                null);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");

        }
    }
}
