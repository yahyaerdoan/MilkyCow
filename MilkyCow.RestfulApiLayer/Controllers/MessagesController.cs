using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.MessageDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public MessagesController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("MessagesList")]
		public ActionResult MessagesList()
		{
			var values = _serviceManger.MessageService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultMessageDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetMessageById/{id}")]
		public ActionResult GetMessageById(int id)
		{
			var values = _serviceManger.MessageService.GetById(id);
			var resultDtos = _mapper.Map<IEnumerable<ResultMessageDto>>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateMessage")]
		public ActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			var values = _mapper.Map<Message>(createMessageDto);
			values.SendingDate = DateTime.Now;
			_serviceManger.MessageService.Add(values);
			return Ok("Message added.");
		}

		[HttpDelete("DeleteMessage/{id}")]
		public ActionResult DeleteMessage(int id)
		{
			_serviceManger.MessageService.Delete(id);
			return Ok("Message deleted.");
		}
		[HttpPut("UpdateMessage")]
		public ActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			var values = _mapper.Map<Message>(updateMessageDto);
			_serviceManger.MessageService.Update(values);
			return Ok("Message updated.");
		}
	}
}
