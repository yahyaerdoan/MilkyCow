﻿using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.SocialMediaDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutTopBarViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultSocialMediaDto> _resultSocialMediaDto;

        public LayoutTopBarViewComponentPartial(DynamicConsume<ResultSocialMediaDto> resultSocialMediaDto)
        {
            _resultSocialMediaDto = resultSocialMediaDto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultSocialMediaDto.GetListAsync("SocialMedias/SocialMediaList");
            var filteredValues= values.Where(x=> x.Status).ToList();
            return View(filteredValues);
        }
    }
}
