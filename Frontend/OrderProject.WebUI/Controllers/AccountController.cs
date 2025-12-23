using MailKit.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.EntityLayer.Concrete;
using OrderProject.WebUI.Models.Acccount;
using OrderProject.WebUI.Models.Mail;
using System.Net.Http;
using System.Text;

namespace OrderProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountController(SignInManager<AppUser> signManager, UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _signManager = signManager;
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                TempData["message"] = "Eposta Adresinizi Giriniz.";
                return View();
            }
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                TempData["message"] = "Eşleşen Mail Yok";
                return View();
            }
           
            
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);//Şifre tokeni
            var url = Url.Action("ResetPassword", "Account", new { Id = user.Id, token }, Request.Scheme);
            string emailBody = $"Lütfen email onayınız <a href='{url}'>tıklayın</a>"; //url oluşturup resete yönlendirdim.
            var mail = new SendEmailViewModel();
            mail.ReceiverMail = user.Email;
            mail.ReceiverName = user.Name;
            mail.Content = emailBody;



            mail.Title = "Şifre Sıfırlama";
            mail.SenderMail = "erkancayiroglu02@gmail.com";
            mail.SenderName = "Kebap ve Pide Salonu";

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(mail);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var orderResponse = await client.PostAsync(
                "http://localhost:5283/api/SendEmail/ForgotPassword", content);

            if (!orderResponse.IsSuccessStatusCode)
            {

                var errorContent = await orderResponse.Content.ReadAsStringAsync();


                Console.WriteLine("Order API error: " + errorContent);


                ViewBag.ApiError = errorContent;

                return View("Error");



              
            }
            TempData["message"] = "Sıfırlayın";
            return View();



        }
        public IActionResult ResetPassword(string id, string token)
        {
            if (id == null || token == null)

            {
                return RedirectToAction("Login");
            }
            var model = new ResetPasswordModel { Token = token };
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    TempData["message"] = "Bu Mail Adresi ile eşleşen mail yok";
                    return RedirectToAction("Login");

                }
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    TempData["message"] = "Şifreniz Değiştirildi";
                    return RedirectToAction("Index", "Login");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);

        }
    }
}
