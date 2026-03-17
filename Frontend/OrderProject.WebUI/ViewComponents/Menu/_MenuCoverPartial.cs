using Microsoft.AspNetCore.Mvc;

namespace OrderProject.WebUI.ViewComponents.Menu
{
    public class _MenuCoverPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
