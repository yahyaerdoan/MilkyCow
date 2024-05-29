using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.WhyUsDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WhyUsController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public WhyUsController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("WhyUsList")]
		public ActionResult WhyUsList()
		{
			var values = _serviceManger.WhyUsService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultWhyUsDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetWhyUsById/{id}")]
		public ActionResult GetWhyUsById(int id)
		{
			var values = _serviceManger.WhyUsService.GetById(id);
			var resultDtos = _mapper.Map<IEnumerable<ResultWhyUsDto>>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateWhyUs")]
		public ActionResult CreateWhyUs(CreateWhyUsDto createWhyUsDto)
		{
			var values = _mapper.Map<WhyUs>(createWhyUsDto);
			_serviceManger.WhyUsService.Add(values);
			return Ok("WhyUs added.");
		}

		[HttpDelete("DeleteWhyUs/{id}")]
		public ActionResult DeleteWhyUs(int id)
		{
			_serviceManger.WhyUsService.Delete(id);
			return Ok("WhyUs deleted.");
		}
		[HttpPut("UpdateWhyUs")]
		public ActionResult UpdateWhyUs(UpdateWhyUsDto updateWhyUsDto)
		{
			var values = _mapper.Map<WhyUs>(updateWhyUsDto);
			_serviceManger.WhyUsService.Update(values);
			return Ok("WhyUs updated.");
		}
	}
}
