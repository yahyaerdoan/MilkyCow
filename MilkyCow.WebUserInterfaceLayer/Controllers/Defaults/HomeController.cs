using Microsoft.AspNetCore.Mvc;

namespace MilkyCow.WebUserInterfaceLayer.Controllers.Defaults
{
    public class HomeController : Controller
    {
        public IActionResult Default()
        {
            ViewData["ActiveController"] = "Home";
            ViewData["ActiveAction"] = "Default";
            return View();
        }
    }
}
