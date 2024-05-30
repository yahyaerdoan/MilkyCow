using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.OurServiceDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class OurServiceController : Controller
    {
        private readonly DynamicConsume<ResultOurServiceDto> _resultOurServiceDto;
        private readonly DynamicConsume<CreateOurServiceDto> _createOurServiceDto;
        private readonly DynamicConsume<UpdateOurServiceDto> _updateOurServiceDto;
        private readonly DynamicConsume<object> _object;

        public OurServiceController(DynamicConsume<ResultOurServiceDto> resultOurServiceDto, DynamicConsume<CreateOurServiceDto> createOurServiceDto, DynamicConsume<UpdateOurServiceDto> updateOurServiceDto, DynamicConsume<object> oobject)
        {
            _resultOurServiceDto = resultOurServiceDto;
            _createOurServiceDto = createOurServiceDto;
            _updateOurServiceDto = updateOurServiceDto;
            _object = oobject;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _resultOurServiceDto.GetListAsync("OurServices/OurServiceList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateOurService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOurService(CreateOurServiceDto createOurServiceDto)
        {
            var values = await _createOurServiceDto.PostAsync("OurServices/CreateOurService", createOurServiceDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOurService(int id)
        {
            var values = await _updateOurServiceDto.GetByIdAsync("OurServices/GetOurServiceById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOurService(UpdateOurServiceDto updateOurServiceDto)
        {
            var values = await _createOurServiceDto.PutAsync("OurServices/UpdateOurService", updateOurServiceDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteOurService(int id)
        {
            var values = await _object.DeleteAsync("OurServices/DeleteOurService", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
