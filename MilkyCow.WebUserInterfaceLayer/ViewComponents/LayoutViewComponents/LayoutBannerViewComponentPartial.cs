using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.BannerDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutBannerViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultBannerDto> _resultBannerDto;

        public LayoutBannerViewComponentPartial(DynamicConsume<ResultBannerDto> resultBannerDto)
        {
            _resultBannerDto = resultBannerDto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultBannerDto.GetListAsync("Banners/BannerList");
            return View(values);
        }
    }
}
