using Microsoft.AspNetCore.Mvc;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutTestimonialViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() {  return View(); }
    }
}
