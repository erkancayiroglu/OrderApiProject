using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OrderProject.WebUI.Dtos.CategoryDto;
using OrderProject.WebUI.Dtos.ReservationDto;

namespace OrderProject.WebUI.ViewComponents.Contact
{
    public class _ContactCoverPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
