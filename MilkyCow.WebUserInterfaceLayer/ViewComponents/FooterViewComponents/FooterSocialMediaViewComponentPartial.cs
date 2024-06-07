using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.SocialMediaDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.FooterViewComponents
{
    public class FooterSocialMediaViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultSocialMediaDto> _resultSocialMediaDto;

        public FooterSocialMediaViewComponentPartial(DynamicConsume<ResultSocialMediaDto> resultSocialMediaDto)
        {
            _resultSocialMediaDto = resultSocialMediaDto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultSocialMediaDto.GetListAsync("SocialMedias/SocialMediaList");
            return View(values);
        }
    }
}
