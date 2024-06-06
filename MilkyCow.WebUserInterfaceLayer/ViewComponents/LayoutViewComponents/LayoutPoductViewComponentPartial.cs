using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.ProductDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutPoductViewComponentPartial :ViewComponent
    {
        private readonly DynamicConsume<ResultProductDto> _dynamicConsume;

        public LayoutPoductViewComponentPartial(DynamicConsume<ResultProductDto> dynamicConsume)
        {
            _dynamicConsume = dynamicConsume;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _dynamicConsume.GetListAsync("Products/ProductList");
            return View(values); 
        }
    }
}
