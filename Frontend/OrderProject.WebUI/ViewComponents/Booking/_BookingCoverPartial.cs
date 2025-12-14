using Microsoft.AspNetCore.Mvc;

namespace OrderProject.WebUI.ViewComponents.Booking
{
    public class _BookingCoverPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
