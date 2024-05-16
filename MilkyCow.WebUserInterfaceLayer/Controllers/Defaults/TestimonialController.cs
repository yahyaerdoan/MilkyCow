using Microsoft.AspNetCore.Mvc;

namespace MilkyCow.WebUserInterfaceLayer.Controllers.Defaults
{
    public class TestimonialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
