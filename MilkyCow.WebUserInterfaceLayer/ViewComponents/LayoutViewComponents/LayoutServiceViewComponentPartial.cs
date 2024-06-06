using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.OurServiceDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutServiceViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultOurServiceDto> _resultOurServiceDto;

        public LayoutServiceViewComponentPartial(DynamicConsume<ResultOurServiceDto> resultOurServiceDto)
        {
            _resultOurServiceDto = resultOurServiceDto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultOurServiceDto.GetListAsync("OurServices/OurServiceList");
            return View(values);
        }
    }
}
