using Microsoft.AspNetCore.Mvc;

namespace MilkyCow.WebUserInterfaceLayer.Controllers.Defaults
{
    public class OurTeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
