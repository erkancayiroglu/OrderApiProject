

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using OrderProject.DtoLayer.OrderDto1;
using OrderProject.EntityLayer.Concrete;
using OrderProject.WebUI.Dtos.OrderDto;
using OrderProject.WebUI.Dtos.SepetDto;
using OrderProject.WebUI.Models.Mail;
using System.Text;

namespace OrderProject.WebUI.Controllers
{
    [AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class AdminOrderController : Controller
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

        [HttpGet]
        public async Task<IActionResult> OrderApproved(int id, int userId)
        {

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(
                $"http://localhost:5283/api/Order/ApprovedOrder/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Sipariş onaylanmadı";
                return View("Error");
            }
            var client2 = _httpClientFactory.CreateClient();

            var response2 = await client2.GetAsync(
                $"http://localhost:5283/api/AppUser/GetUser/{userId}");

            if (!response2.IsSuccessStatusCode)
            {
                ViewBag.Error = "Kullanıcı Bulunamadı";
                return View("Error");
            }
            var userJson = await response2.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<AppUser>(userJson);
            var mail = new SendEmailViewModel();
            mail.ReceiverMail = user.Email;
            mail.ReceiverName = user.Name;
            mail.Content = "Siparişiniz Onaylandı En kısa sürede Hazırlanacaktır" + "Bilginize...";


            mail.OrderId = id;
            mail.Title = "Sipariş Bilgisi";
            mail.SenderMail = "erkancayiroglu02@gmail.com";
            mail.SenderName = "Kebap ve Pide Salonu";

            var client3 = _httpClientFactory.CreateClient();
            var json3 = JsonConvert.SerializeObject(mail);
            var content3 = new StringContent(json3, Encoding.UTF8, "application/json");


            var orderResponse3 = await client3.PostAsync(
                "http://localhost:5283/api/SendEmail", content3);

            if (!orderResponse3.IsSuccessStatusCode)
            {

                var errorContent = await orderResponse3.Content.ReadAsStringAsync();


                Console.WriteLine("Order API error: " + errorContent);


                ViewBag.ApiError = errorContent;

                return View("Error");
            }
            return RedirectToAction("Index");


        }
        [HttpGet]
        public async Task<IActionResult> PrepareOrder(int id, int userId)
        {

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(
                $"http://localhost:5283/api/Order/PrepareOrder/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Sipariş Hazırlama işlemi olmadı";
                return View("Error");
            }
            var client2 = _httpClientFactory.CreateClient();

            var response2 = await client2.GetAsync(
                $"http://localhost:5283/api/AppUser/GetUser/{userId}");

            if (!response2.IsSuccessStatusCode)
            {
                ViewBag.Error = "Kullanıcı Bulunamadı";
                return View("Error");
            }
            var userJson = await response2.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<AppUser>(userJson);
            var mail = new SendEmailViewModel();
            mail.ReceiverMail = user.Email;
            mail.ReceiverName = user.Name;
            mail.Content = "Siparişiniz Hazırlanıyor En kısa sürede Yola çıkacaktır." + "Bilginize...";


            mail.OrderId = id;
            mail.Title = "Sipariş Bilgisi";
            mail.SenderMail = "erkancayiroglu02@gmail.com";
            mail.SenderName = "Kebap ve Pide Salonu";

            var client3 = _httpClientFactory.CreateClient();
            var json3 = JsonConvert.SerializeObject(mail);
            var content3 = new StringContent(json3, Encoding.UTF8, "application/json");


            var orderResponse3 = await client3.PostAsync(
                "http://localhost:5283/api/SendEmail", content3);

            if (!orderResponse3.IsSuccessStatusCode)
            {

                var errorContent = await orderResponse3.Content.ReadAsStringAsync();


                Console.WriteLine("Order API error: " + errorContent);


                ViewBag.ApiError = errorContent;

                return View("Error");
            }
            return RedirectToAction("Index");


        }
        [HttpGet]
        public async Task<IActionResult> WayOrder(int id, int userId)
        {

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(
                $"http://localhost:5283/api/Order/WayOrder/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Sipariş Yola Çıkmadı";
                return View("Error");
            }
            var client2 = _httpClientFactory.CreateClient();

            var response2 = await client2.GetAsync(
                $"http://localhost:5283/api/AppUser/GetUser/{userId}");

            if (!response2.IsSuccessStatusCode)
            {
                ViewBag.Error = "Kullanıcı Bulunamadı";
                return View("Error");
            }
            var userJson = await response2.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<AppUser>(userJson);
            var mail = new SendEmailViewModel();
            mail.ReceiverMail = user.Email;
            mail.ReceiverName = user.Name;
            mail.Content = "Siparişiniz Yolda En kısa sürede Teslim Edilecektir." + "Bilginize...";


            mail.OrderId = id;
            mail.Title = "Sipariş Bilgisi";
            mail.SenderMail = "erkancayiroglu02@gmail.com";
            mail.SenderName = "Kebap ve Pide Salonu";

            var client3 = _httpClientFactory.CreateClient();
            var json3 = JsonConvert.SerializeObject(mail);
            var content3 = new StringContent(json3, Encoding.UTF8, "application/json");


            var orderResponse3 = await client3.PostAsync(
                "http://localhost:5283/api/SendEmail", content3);

            if (!orderResponse3.IsSuccessStatusCode)
            {

                var errorContent = await orderResponse3.Content.ReadAsStringAsync();


                Console.WriteLine("Order API error: " + errorContent);


                ViewBag.ApiError = errorContent;

                return View("Error");
            }
            return RedirectToAction("Index");


        }

        [HttpGet]
        public async Task<IActionResult> DeliverOrder(int id, int userId)
        {

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(
                $"http://localhost:5283/api/Order/DeliverOrder/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Sipariş teslim Edilemedi";
                return View("Error");
            }
            var client2 = _httpClientFactory.CreateClient();

            var response2 = await client2.GetAsync(
                $"http://localhost:5283/api/AppUser/GetUser/{userId}");

            if (!response2.IsSuccessStatusCode)
            {
                ViewBag.Error = "Kullanıcı Bulunamadı";
                return View("Error");
            }
            var userJson = await response2.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<AppUser>(userJson);
            var mail = new SendEmailViewModel();
            mail.ReceiverMail = user.Email;
            mail.ReceiverName = user.Name;
            mail.Content = "Siparişiniz Teslim Edildi" +
                " Bizi Tercih Ettiğiniz için teşekkürler";


            mail.OrderId = id;
            mail.Title = "Sipariş Bilgisi";
            mail.SenderMail = "erkancayiroglu02@gmail.com";
            mail.SenderName = "Kebap ve Pide Salonu";

            var client3 = _httpClientFactory.CreateClient();
            var json3 = JsonConvert.SerializeObject(mail);
            var content3 = new StringContent(json3, Encoding.UTF8, "application/json");


            var orderResponse3 = await client3.PostAsync(
                "http://localhost:5283/api/SendEmail", content3);

            if (!orderResponse3.IsSuccessStatusCode)
            {

                var errorContent = await orderResponse3.Content.ReadAsStringAsync();


                Console.WriteLine("Order API error: " + errorContent);


                ViewBag.ApiError = errorContent;

                return View("Error");
            }
            return RedirectToAction("Index");


        }
    }
}

