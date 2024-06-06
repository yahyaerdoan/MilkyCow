using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.AboutUsDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutAboutViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultAboutUsDto> _resultAboutUsDto;

        public LayoutAboutViewComponentPartial(DynamicConsume<ResultAboutUsDto> resultAboutUsDto)
        {
            _resultAboutUsDto = resultAboutUsDto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultAboutUsDto.GetListAsync("AboutUs/AboutUsList");

            return View(values);
        }
    }
}
