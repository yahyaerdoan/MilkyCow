using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.SliderDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class SliderController : Controller
    {       
        private readonly DynamicConsume<ResultSliderDto> _resultSliderDto;
        private readonly DynamicConsume<CreateSliderDto> _createSliderDto;
        private readonly DynamicConsume<UpdateSliderDto> _updateSliderDto;
        private readonly DynamicConsume<object> _object;

        public SliderController(DynamicConsume<ResultSliderDto> resultSliderDto, DynamicConsume<CreateSliderDto> createSliderDto, DynamicConsume<UpdateSliderDto> updateSliderDto, DynamicConsume<object> oobject)
        {
            _resultSliderDto = resultSliderDto;
            _createSliderDto = createSliderDto;
            _updateSliderDto = updateSliderDto;
            _object = oobject;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _resultSliderDto.GetListAsync("Sliders/SliderList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            var values = await _createSliderDto.PostAsync("Sliders/CreateSlider", createSliderDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var values = await _updateSliderDto.GetByIdAsync("Sliders/GetSliderById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var values = await _createSliderDto.PutAsync("Sliders/UpdateSlider", updateSliderDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var values = await _object.DeleteAsync("Sliders/DeleteSlider", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
