using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

using OrderProject.WebUI.Dtos.MessageCategoryDto;

namespace OrderProject.WebUI.ViewComponents.Contact
{
    public class _ContactMessagePartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ContactMessagePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/MessageCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var messageList = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);
                ViewBag.MessageCategoryList = new SelectList(messageList, "MessageCategoryID", "MessageCategoryName");
            }
            return View();
        }
    }
}
