using Microsoft.AspNetCore.Mvc;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
