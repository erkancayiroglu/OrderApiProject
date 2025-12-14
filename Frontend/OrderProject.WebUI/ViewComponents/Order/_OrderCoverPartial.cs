using Microsoft.AspNetCore.Mvc;

namespace OrderProject.WebUI.ViewComponents.Order
{
    public class _OrderCoverPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
