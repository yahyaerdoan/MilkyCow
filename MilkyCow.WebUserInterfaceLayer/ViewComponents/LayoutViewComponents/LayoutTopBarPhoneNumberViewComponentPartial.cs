using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.AddressDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutTopBarPhoneNumberViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultAddressDto> _resultAddressDto;

        public LayoutTopBarPhoneNumberViewComponentPartial(DynamicConsume<ResultAddressDto> resultAddressDto)
        {
            _resultAddressDto = resultAddressDto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultAddressDto.GetListAsync("Addresses/AddressList");
            return View(values);
        }
    }
}
