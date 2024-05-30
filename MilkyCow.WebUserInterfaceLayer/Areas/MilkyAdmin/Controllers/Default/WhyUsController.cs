using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.WhyUsDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class WhyUsController : Controller
    {
        private readonly DynamicConsume<ResultWhyUsDto> _resultWhyUsDto;
        private readonly DynamicConsume<CreateWhyUsDto> _createWhyUsDto;
        private readonly DynamicConsume<UpdateWhyUsDto> _updateWhyUsDto;
        private readonly DynamicConsume<object> _object;

        public WhyUsController(DynamicConsume<ResultWhyUsDto> resultWhyUsDto, DynamicConsume<CreateWhyUsDto> createWhyUsDto, DynamicConsume<UpdateWhyUsDto> updateWhyUsDto, DynamicConsume<object> oobject)
        {
            _resultWhyUsDto = resultWhyUsDto;
            _createWhyUsDto = createWhyUsDto;
            _updateWhyUsDto = updateWhyUsDto;
            _object = oobject;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _resultWhyUsDto.GetListAsync("WhyUs/WhyUsList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateWhyUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhyUs(CreateWhyUsDto createWhyUsDto)
        {
            var values = await _createWhyUsDto.PostAsync("WhyUs/CreateWhyUs", createWhyUsDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWhyUs(int id)
        {
            var values = await _updateWhyUsDto.GetByIdAsync("WhyUs/GetWhyUsById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWhyUs(UpdateWhyUsDto updateWhyUsDto)
        {
            var values = await _createWhyUsDto.PutAsync("WhyUs/UpdateWhyUs", updateWhyUsDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteWhyUs(int id)
        {
            var values = await _object.DeleteAsync("WhyUs/DeleteWhyUs", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    } 
}
