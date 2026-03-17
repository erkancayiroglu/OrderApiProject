using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.DtoLayer.OrderDto1;
using OrderProject.EntityLayer.Concrete;
using OrderProject.WebUI.Dtos.OrderDto;
using static NuGet.Packaging.PackagingConstants;

namespace OrderProject.WebUI.Controllers
{

    [Authorize(Roles ="Müşteri")]
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;
        public OrderController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            int userId = user.Id;

           
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(
                $"http://localhost:5283/api/Order/GetOrder/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Sipariş bulunamadı.";
                return View(new List<OrderUserUIDto>()); 
            }

            var json = await response.Content.ReadAsStringAsync();

            var orders = JsonConvert.DeserializeObject<List<OrderUserUIDto>>(json)
                         ?? new List<OrderUserUIDto>(); 

            return View(orders);
        }
    }
}
