using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.WhyUsDetailDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class WhyUsDetailController : Controller
    {
        private readonly DynamicConsume<ResultWhyUsDetailDto> _resultWhyUsDetailDto;
        private readonly DynamicConsume<CreateWhyUsDetailDto> _createWhyUsDetailDto;
        private readonly DynamicConsume<UpdateWhyUsDetailDto> _updateWhyUsDetailDto;
        private readonly DynamicConsume<object> _object;

        public WhyUsDetailController(DynamicConsume<ResultWhyUsDetailDto> resultWhyUsDetailDto, DynamicConsume<CreateWhyUsDetailDto> createWhyUsDetailDto, DynamicConsume<UpdateWhyUsDetailDto> updateWhyUsDetailDto, DynamicConsume<object> oobject)
        {
            _resultWhyUsDetailDto = resultWhyUsDetailDto;
            _createWhyUsDetailDto = createWhyUsDetailDto;
            _updateWhyUsDetailDto = updateWhyUsDetailDto;
            _object = oobject;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _resultWhyUsDetailDto.GetListAsync("WhyUsDetails/WhyUsDetailList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateWhyUsDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhyUsDetail(CreateWhyUsDetailDto createWhyUsDetailDto)
        {
            var values = await _createWhyUsDetailDto.PostAsync("WhyUsDetails/CreateWhyUsDetail", createWhyUsDetailDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWhyUsDetail(int id)
        {
            var values = await _updateWhyUsDetailDto.GetByIdAsync("WhyUsDetails/GetWhyUsDetailById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWhyUsDetail(UpdateWhyUsDetailDto updateWhyUsDetailDto)
        {
            var values = await _createWhyUsDetailDto.PutAsync("WhyUsDetails/UpdateWhyUsDetail", updateWhyUsDetailDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteWhyUsDetail(int id)
        {
            var values = await _object.DeleteAsync("WhyUsDetails/DeleteWhyUsDetail", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
