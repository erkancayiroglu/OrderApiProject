using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProject.EntityLayer.Concrete;
using OrderProject.WebUI.Dtos.RegisterDto;

namespace OrderProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public RegisterController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
                return View(createUserDto);

           
            var emailExists = await _userManager.Users
                .AnyAsync(x => x.Email == createUserDto.Email);

            var usernameExist = await _userManager.Users
                .AnyAsync(x => x.UserName == createUserDto.UserName);

            if (emailExists)
            {
                ModelState.AddModelError("Email", "Bu email zaten kayıtlı.");
                return View(createUserDto);
            }
            if (usernameExist)
            {
                ModelState.AddModelError("UserName", "Bu username zaten kayıtlı.");
                return View(createUserDto);
            }

            var appUser = _mapper.Map<AppUser>(createUserDto);
           
            var result = await _userManager.CreateAsync(appUser, createUserDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(createUserDto);
          
        }
    }
}
