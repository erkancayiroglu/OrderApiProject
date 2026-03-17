using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OrderProject.WebUI.Dtos.ReservationDto;


namespace OrderProject.WebUI.ViewComponents.Booking
{
    public class _ReservationPartial: ViewComponent

    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ReservationPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5283/api/Restaurant");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var restaurantList = JsonConvert.DeserializeObject<List<ResultRestaurantDto>>(jsonData);
                ViewBag.RestaurantNameList = new SelectList(restaurantList, "RestaurantID", "RestaurantName");
            }
            return View();
        }
    }
}
