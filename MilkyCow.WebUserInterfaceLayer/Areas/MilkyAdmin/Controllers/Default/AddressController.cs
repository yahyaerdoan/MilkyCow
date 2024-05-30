using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.AddressDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class AddressController : Controller
    {
        private readonly DynamicConsume<ResultAddressDto> _resultAddressDto;
        private readonly DynamicConsume<CreateAddressDto> _createAddressDto;
        private readonly DynamicConsume<UpdateAddressDto> _updateAddressDto;
        private readonly DynamicConsume<object> _object;

        public AddressController(DynamicConsume<ResultAddressDto> resultAddressDto, DynamicConsume<CreateAddressDto> createAddressDto, DynamicConsume<UpdateAddressDto> updateAddressDto, DynamicConsume<object> oobject)
        {
            _resultAddressDto = resultAddressDto;
            _createAddressDto = createAddressDto;
            _updateAddressDto = updateAddressDto;
            _object = oobject;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _resultAddressDto.GetListAsync("Addresses/AddressList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAddress()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressDto createAddressDto)
        {
            var values = await _createAddressDto.PostAsync("Addresses/CreateAddress", createAddressDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAddress(int id)
        {
            var values = await _updateAddressDto.GetByIdAsync("Addresses/GetAddressById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAddress(UpdateAddressDto updateAddressDto)
        {
            var values = await _createAddressDto.PutAsync("Addresses/UpdateAddress", updateAddressDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var values = await _object.DeleteAsync("Addresses/DeleteAddress", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    } 
}
