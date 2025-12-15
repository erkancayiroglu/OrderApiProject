

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using OrderProject.WebUI.Dtos.OrderDto;

namespace OrderProject.WebUI.Controllers
{
   
    public class AdminOrderController:Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminOrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/Order/GetOrders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<OrderListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
