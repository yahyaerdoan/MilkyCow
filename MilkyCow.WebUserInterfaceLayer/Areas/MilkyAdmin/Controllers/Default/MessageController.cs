using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.MessageDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class MessageController : Controller
    {
        private readonly DynamicConsume<ResultMessageDto> _resultMessageDto;
        private readonly DynamicConsume<CreateMessageDto> _createMessageDto;
        private readonly DynamicConsume<UpdateMessageDto> _updateMessageDto;
        private readonly DynamicConsume<object> _object;

        public MessageController(DynamicConsume<ResultMessageDto> resultMessageDto, DynamicConsume<CreateMessageDto> createMessageDto, DynamicConsume<UpdateMessageDto> updateMessageDto, DynamicConsume<object> oobject)
        {
            _resultMessageDto = resultMessageDto;
            _createMessageDto = createMessageDto;
            _updateMessageDto = updateMessageDto;
            _object = oobject;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _resultMessageDto.GetListAsync("Messages/MessageList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            var values = await _createMessageDto.PostAsync("Messages/CreateMessage", createMessageDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMessage(int id)
        {
            var values = await _updateMessageDto.GetByIdAsync("Messages/GetMessageById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var values = await _createMessageDto.PutAsync("Messages/UpdateMessage", updateMessageDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var values = await _object.DeleteAsync("Messages/DeleteMessage", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    } 
}
