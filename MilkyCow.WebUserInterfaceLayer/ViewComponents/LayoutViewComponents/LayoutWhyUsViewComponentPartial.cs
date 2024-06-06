using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.WhyUsDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutWhyUsViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultWhyUsDto> _resultWhyUsDto;

        public LayoutWhyUsViewComponentPartial(DynamicConsume<ResultWhyUsDto> resultWhyUsDto)
        {
            _resultWhyUsDto = resultWhyUsDto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultWhyUsDto.GetListAsync("WhyUs/WhyUsList");
            return View(values);
        }
    }
}
