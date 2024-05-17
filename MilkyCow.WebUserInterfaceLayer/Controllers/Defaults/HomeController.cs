using Microsoft.AspNetCore.Mvc;

namespace MilkyCow.WebUserInterfaceLayer.Controllers.Defaults
{
    public class HomeController : Controller
    {
        public IActionResult Default()
        {
            return View();
        }
    }
}
