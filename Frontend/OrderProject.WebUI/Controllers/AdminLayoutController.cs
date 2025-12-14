using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProject.WebUI.Dtos.CategoryDto;
using System.Net.Http;

namespace OrderProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminLayoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> _AdminLayout()
        {
            

            return View();

        }
        public PartialViewResult HeadPartial()
        {
         return PartialView();

        }
        public PartialViewResult PreloaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptsPartial()
        {
            return PartialView();
        }

    }
}
