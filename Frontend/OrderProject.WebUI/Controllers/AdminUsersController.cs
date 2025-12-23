using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.WebUI.Dtos.AdminUserDto;
using OrderProject.WebUI.Dtos.ProductDto;

namespace OrderProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; 
        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); 
            var responseMessage = await client.GetAsync("http://localhost:5283/api/AppUser");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUsersDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
