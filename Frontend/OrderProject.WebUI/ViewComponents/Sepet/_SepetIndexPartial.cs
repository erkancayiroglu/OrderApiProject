using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.EntityLayer.Concrete;
using OrderProject.WebUI.Dtos.SepetDto;

namespace OrderProject.WebUI.ViewComponents.Sepet
{
    public class _SepetIndexPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public _SepetIndexPartial(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Giriş yapan user'ı al
            var user = await _userManager.GetUserAsync(HttpContext.User);
            int userId = user.Id;

            var client = _httpClientFactory.CreateClient();

            var responseMessage =
                await client.GetAsync($"http://localhost:5283/api/SepetItem/GetUserSepet/{userId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultSepetDto>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
