using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.ServiceTypeDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class ServiceTypeController : Controller
    {        
        private readonly DynamicConsume<ResultServiceTypeDto> _resultServiceTypeDto;
        private readonly DynamicConsume<CreateServiceTypeDto> _createServiceTypeDto;
        private readonly DynamicConsume<UpdateServiceTypeDto> _updateServiceTypeDto;
        private readonly DynamicConsume<object> _object;

        public ServiceTypeController(DynamicConsume<ResultServiceTypeDto> resultServiceTypeDto, DynamicConsume<CreateServiceTypeDto> createServiceTypeDto, DynamicConsume<UpdateServiceTypeDto> updateServiceTypeDto, DynamicConsume<object> oobject)
        {
            _resultServiceTypeDto = resultServiceTypeDto;
            _createServiceTypeDto = createServiceTypeDto;
            _updateServiceTypeDto = updateServiceTypeDto;
            _object = oobject;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _resultServiceTypeDto.GetListAsync("ServiceTypes/ServiceTypeList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateServiceType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceType(CreateServiceTypeDto createServiceTypeDto)
        {
            var values = await _createServiceTypeDto.PostAsync("ServiceTypes/CreateServiceType", createServiceTypeDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateServiceType(int id)
        {
            var values = await _updateServiceTypeDto.GetByIdAsync("ServiceTypes/GetServiceTypeById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateServiceType(UpdateServiceTypeDto updateServiceTypeDto)
        {
            var values = await _createServiceTypeDto.PutAsync("ServiceTypes/UpdateServiceType", updateServiceTypeDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteServiceType(int id)
        {
            var values = await _object.DeleteAsync("ServiceTypes/DeleteServiceType", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
