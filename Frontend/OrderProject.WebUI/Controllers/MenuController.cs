using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.WebUI.Dtos.ProductDto;

namespace OrderProject.WebUI.Controllers
{
    public class MenuController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5283/api/Product/GetProductList?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CategoryProductDto>>(jsonData);
              
                return View(values);
            }
            return View();
        }

    }
}

