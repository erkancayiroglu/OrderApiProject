using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.EntityLayer.Concrete;
using OrderProject.WebUI.Dtos.CategoryDto;
using OrderProject.WebUI.Dtos.ProductDto;
using System.Text;


namespace OrderProject.WebUI.Controllers
{
    [AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; 
        public AdminCategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> AddCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5283/api/Category", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage =  client.DeleteAsync($"http://localhost:5283/api/Category/{id}");
            if (responseMessage.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage =  client.GetAsync($"http://localhost:5283/api/Category/{id}");
            if (responseMessage.Result.IsSuccessStatusCode)
            {
                var jsonData = responseMessage.Result.Content.ReadAsStringAsync().Result;
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5283/api/Category", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateCategoryDto);
        }
        public async Task<IActionResult> GetProductList(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5283/api/Product/GetProductList?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CategoryProductDto>>(jsonData);
                ViewBag.categoryId = id;
                return View(values);
            }
            return View();
        }
       
    }
}
