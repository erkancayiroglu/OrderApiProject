using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderProject.EntityLayer.Concrete;
using OrderProject.WebUI.Dtos.CategoryDto;
using OrderProject.WebUI.Dtos.ProductDto;
using System.Text;

namespace OrderProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public AdminProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync($"http://localhost:5283/api/Product/{id}");

            await FillCategoryDropdown(id);


            if (responsMessage.IsSuccessStatusCode)
            {
                // ---- 1) Ürün bilgisi ----
                var jsondata = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsondata);

                if (values == null)
                    return NotFound();

               
                return View(values);
            }


            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductDto updateProductDto, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
             
                await FillCategoryDropdown(updateProductDto.CategoryId);

               
                if (imageFile != null && imageFile.Length > 0)
                {
                    updateProductDto.ImageUrl = imageFile.FileName;
                }

                return View(updateProductDto);
            }

           
            if (imageFile != null && imageFile.Length > 0)
            {
             
                // Burada kendi API veya storage servisine gönderip URL al
                updateProductDto.ImageUrl = imageFile.FileName;
            }

            // PUT request
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateProductDto);
            var stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5283/api/Product", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            // PUT başarısız olursa kategori dropdown tekrar doldur
            await FillCategoryDropdown(updateProductDto.CategoryId);

            return View(updateProductDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync($"http://localhost:5283/api/Product/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5283/api/Category");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 =await responseMessage2.Content.ReadAsStringAsync();
                var categoryList = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
                // 3. ViewBag'i SelectList Olarak Hazırlama
                // "Id" değeri (value), "Name" metni (text) olacak ve mevcut ürünün CategoryId'si seçili gelecek.
                ViewBag.CategorySelectList = new SelectList(
                    categoryList,
                    "Id",
                    "Name"
                  );
            }
                
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto createProductDto, IFormFile imageFile)
        {
           
            if (imageFile != null && imageFile.Length > 0)
            {
                // Sadece dosya adını alıyoruz
                createProductDto.ImageUrl = imageFile.FileName;
            }

            // 2) API'ye JSON gönder
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createProductDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5283/api/Product", content);

            // 3) Hata kontrolü
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("---- API ERROR ----");
                Console.WriteLine("Status: " + response.StatusCode);

                var apiMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Content: " + apiMessage);

                return View(createProductDto);
            }

            return RedirectToAction("Index");
        }
        private async Task FillCategoryDropdown(int selectedCategoryId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categoryList = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                ViewBag.CategorySelectList = new SelectList(categoryList, "Id", "Name", selectedCategoryId);
            }
        }

       

        



    }
}
