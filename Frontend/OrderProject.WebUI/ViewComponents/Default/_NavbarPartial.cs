using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.WebUI.Dtos.CategoryDto;

namespace OrderProject.WebUI.ViewComponents.Default
{
    public class _NavbarPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _NavbarPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
