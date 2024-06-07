using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.GalleryDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutGalleryViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultGalleryDto> _resultGalleryDto;

        public LayoutGalleryViewComponentPartial(DynamicConsume<ResultGalleryDto> resultGalleryDto)
        {
            _resultGalleryDto = resultGalleryDto;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _resultGalleryDto.GetListAsync("Galleries/GalleryList");
            return View(values); 
        }
    }
}
