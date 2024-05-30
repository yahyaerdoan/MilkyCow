using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.TestimonialDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class TestimonialController : Controller
    {
        private readonly DynamicConsume<ResultTestimonialDto> _resultTestimonialDto;
        private readonly DynamicConsume<CreateTestimonialDto> _createTestimonialDto;
        private readonly DynamicConsume<UpdateTestimonialDto> _updateTestimonialDto;
        private readonly DynamicConsume<object> _object;
        public TestimonialController(DynamicConsume<ResultTestimonialDto> resultTestimonialDto, DynamicConsume<CreateTestimonialDto> createTestimonialDto, DynamicConsume<UpdateTestimonialDto> updateTestimonialDto, DynamicConsume<object> oobject)
        {
            _resultTestimonialDto = resultTestimonialDto;
            _createTestimonialDto = createTestimonialDto;
            _updateTestimonialDto = updateTestimonialDto;
            _object = oobject;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _resultTestimonialDto.GetListAsync("Testimonials/TestimonialList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var values = await _createTestimonialDto.PostAsync("Testimonials/CreateTestimonial", createTestimonialDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var values = await _updateTestimonialDto.GetByIdAsync("Testimonials/GetTestimonialById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var values = await _createTestimonialDto.PutAsync("Testimonials/UpdateTestimonial", updateTestimonialDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var values = await _object.DeleteAsync("Testimonials/DeleteTestimonial", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
