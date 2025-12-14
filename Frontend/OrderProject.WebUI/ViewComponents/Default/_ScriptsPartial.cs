using Microsoft.AspNetCore.Mvc;

namespace OrderProject.WebUI.ViewComponents.Default
{
    public class _ScriptsPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
