using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.BusinessHourDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class BusinessHourController : Controller
    {
        private readonly DynamicConsume<ResultBusinessHourDto> _resultBusinessHourDto;
        private readonly DynamicConsume<CreateBusinessHourDto> _createBusinessHourDto;
        private readonly DynamicConsume<UpdateBusinessHourDto> _updateBusinessHourDto;
        private readonly DynamicConsume<object> _object;

        public BusinessHourController(DynamicConsume<ResultBusinessHourDto> resultBusinessHourDto, DynamicConsume<CreateBusinessHourDto> createBusinessHourDto, DynamicConsume<UpdateBusinessHourDto> updateBusinessHourDto, DynamicConsume<object> oobject)
        {
            _resultBusinessHourDto = resultBusinessHourDto;
            _createBusinessHourDto = createBusinessHourDto;
            _updateBusinessHourDto = updateBusinessHourDto;
            _object = oobject;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _resultBusinessHourDto.GetListAsync("BusinessHours/BusinessHourList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBusinessHour()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessHour(CreateBusinessHourDto createBusinessHourDto)
        {
            var values = await _createBusinessHourDto.PostAsync("BusinessHours/CreateBusinessHour", createBusinessHourDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBusinessHour(int id)
        {
            var values = await _updateBusinessHourDto.GetByIdAsync("BusinessHours/GetBusinessHourById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBusinessHour(UpdateBusinessHourDto updateBusinessHourDto)
        {
            var values = await _createBusinessHourDto.PutAsync("BusinessHours/UpdateBusinessHour", updateBusinessHourDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteBusinessHour(int id)
        {
            var values = await _object.DeleteAsync("BusinessHours/DeleteBusinessHour", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
