using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.TestimonialDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutTestimonialViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultTestimonialDto> _resultTestimonialDto;

        public LayoutTestimonialViewComponentPartial(DynamicConsume<ResultTestimonialDto> resultTestimonialDto)
        {
            _resultTestimonialDto = resultTestimonialDto;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _resultTestimonialDto.GetListAsync("Testimonials/TestimonialList");
            return View(values); 
        }
    }
}
