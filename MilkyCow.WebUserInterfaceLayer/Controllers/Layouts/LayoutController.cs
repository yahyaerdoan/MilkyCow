using Microsoft.AspNetCore.Mvc;

namespace MilkyCow.WebUserInterfaceLayer.Controllers.Layouts
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
