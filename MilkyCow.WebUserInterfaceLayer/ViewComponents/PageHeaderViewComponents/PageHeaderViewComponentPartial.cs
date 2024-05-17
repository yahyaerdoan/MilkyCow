using Microsoft.AspNetCore.Mvc;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.PageHeaderViewComponents
{
    public class PageHeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(string title) { return View("Default", title); }
    }
}
