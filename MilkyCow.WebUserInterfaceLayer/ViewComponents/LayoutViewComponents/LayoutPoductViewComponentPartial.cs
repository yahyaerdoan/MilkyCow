using Microsoft.AspNetCore.Mvc;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutPoductViewComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke() 
        {  
            return View(); 
        }
    }
}
