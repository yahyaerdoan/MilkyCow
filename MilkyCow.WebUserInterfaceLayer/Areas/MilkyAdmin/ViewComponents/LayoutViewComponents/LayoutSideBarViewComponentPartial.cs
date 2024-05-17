using Microsoft.AspNetCore.Mvc;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.ViewComponents.LayoutViewComponents
{
    public class LayoutSideBarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() {  return View(); }
    }
}
