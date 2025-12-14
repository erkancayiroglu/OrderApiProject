using Microsoft.AspNetCore.Mvc;

namespace OrderProject.WebUI.ViewComponents.Default
{
    public class _GalleryPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
