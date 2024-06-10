using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.MessageDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;
using MilkyCow.WebUserInterfaceLayer.Extensions.NToastNotify.AlertMessages;
using NToastNotify;

namespace MilkyCow.WebUserInterfaceLayer.Controllers.Defaults
{
    public class ContactController : Controller
    {
        private readonly DynamicConsume<CreateMessageDto>  _createMessageDto;
        private readonly IToastNotification _toastNotification;

        public ContactController(DynamicConsume<CreateMessageDto> createMessageDto, IToastNotification toastNotification)
        {
            _createMessageDto = createMessageDto;
            _toastNotification = toastNotification;
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
                _toastNotification.AddSuccessToastMessage(MessageForUI.Success, 
                    new ToastrOptions { Title = "Successfully!"});
                return RedirectToAction("Default", "Home");

            }
            _toastNotification.AddErrorToastMessage(MessageForUI.Error, 
                new ToastrOptions { Title = "Error!" });
            return RedirectToAction("Index", "Contact");
        }
    }
}
