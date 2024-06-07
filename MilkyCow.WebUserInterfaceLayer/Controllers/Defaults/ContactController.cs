using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.MessageDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Controllers.Defaults
{
    public class ContactController : Controller
    {
        private readonly DynamicConsume<CreateMessageDto>  _createMessageDto;

        public ContactController(DynamicConsume<CreateMessageDto> createMessageDto)
        {
            _createMessageDto = createMessageDto;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var values =  await _createMessageDto.PostAsync("Messages/CreateMessage", createMessageDto);
            if (values > 0)
            {
                return RedirectToAction("Default", "Home");

            }
            return View(createMessageDto);
        }
    }
}
