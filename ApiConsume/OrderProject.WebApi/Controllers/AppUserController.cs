using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.BusinessLayer.Abstract;

namespace OrderProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult GetAppUsers()
        {
            var values = _appUserService.TGetList();
            return Ok(values);
        }
    }
}
