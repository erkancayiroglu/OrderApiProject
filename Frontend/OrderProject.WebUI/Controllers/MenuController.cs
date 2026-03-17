using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.EntityLayer.Concrete;
using OrderProject.WebUI.Dtos.ProductDto;

namespace OrderProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int? id)
        {

            if (id == null)
            {
                // 🔹 TÜM ÜRÜNLER
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("http://localhost:5283/api/Product");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<CategoryProductDto>>(jsonData);
                    return View(values);
                }

                return View();
            }
            else
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
}

