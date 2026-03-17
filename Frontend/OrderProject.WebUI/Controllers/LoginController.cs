using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using OrderProject.EntityLayer.Concrete;
using OrderProject.WebUI.Dtos.LoginDto;

namespace OrderProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
       
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginUserDto);
            }

            var result = await _signInManager.PasswordSignInAsync(
                loginUserDto.Username,
                loginUserDto.Password,
                false,
                false
            );

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Default");
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            return View(loginUserDto);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
        

    }
}
