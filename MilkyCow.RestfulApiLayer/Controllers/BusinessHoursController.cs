using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.BannerDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.BusinessHourDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BusinessHoursController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public BusinessHoursController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("BusinessHoursList")]
		public ActionResult BusinessHoursList()
		{
			var values = _serviceManger.BusinessHourService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultBusinessHourDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetBusinessHourById/{id}")]
		public ActionResult GetBusinessHourById(int id)
		{
			var values = _serviceManger.BusinessHourService.GetById(id);
			var resultDtos = _mapper.Map<BusinessHour,ResultBusinessHourDto>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateBusinessHour")]
		public ActionResult CreateBanner(CreateBusinessHourDto createBusinessHourDto)
		{
			var values = _mapper.Map<BusinessHour>(createBusinessHourDto);
			_serviceManger.BusinessHourService.Add(values);
			return Ok("BusinessHour added.");
		}

		[HttpDelete("DeleteBusinessHour/{id}")]
		public ActionResult DeleteBusinessHour(int id)
		{
			_serviceManger.BusinessHourService.Delete(id);
			return Ok("BusinessHour deleted.");
		}
		[HttpPut("UpdateBusinessHour")]
		public ActionResult UpdateBusinessHour(UpdateBusinessHourDto  updateBusinessHourDto)
		{
			var values = _mapper.Map<BusinessHour>(updateBusinessHourDto);
			_serviceManger.BusinessHourService.Update(values);
			return Ok("BusinessHour updated.");
		}
	}
}
