using Microsoft.AspNetCore.Mvc;

namespace OrderProject.WebUI.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
