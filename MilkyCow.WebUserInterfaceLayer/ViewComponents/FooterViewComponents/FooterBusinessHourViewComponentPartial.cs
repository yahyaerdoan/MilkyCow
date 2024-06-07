using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.BusinessHourDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.FooterViewComponents
{
    public class FooterBusinessHourViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultBusinessHourDto> _resultBusinessHourDto;

        public FooterBusinessHourViewComponentPartial(DynamicConsume<ResultBusinessHourDto> resultBusinessHourDto)
        {
            _resultBusinessHourDto = resultBusinessHourDto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultBusinessHourDto.GetListAsync("BusinessHours/BusinessHourList");
            return View(values);
        }
    }
}
