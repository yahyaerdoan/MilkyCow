using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.WhyUsDetailDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutWhyUsDetailViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultWhyUsDetailDto> _resultWhyUsDetailDto;

        public LayoutWhyUsDetailViewComponentPartial(DynamicConsume<ResultWhyUsDetailDto> resultWhyUsDetailDto)
        {
            _resultWhyUsDetailDto = resultWhyUsDetailDto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values= await _resultWhyUsDetailDto.GetListAsync("WhyUsDetails/WhyUsDetailList");
            return View(values);
        }
    }
}
