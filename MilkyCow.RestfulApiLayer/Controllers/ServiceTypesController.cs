using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.ServiceTypeDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiceTypesController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public ServiceTypesController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("ServiceTypesList")]
		public ActionResult ServiceTypesList()
		{
			var values = _serviceManger.ServiceTypeService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultServiceTypeDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetServiceTypeById/{id}")]
		public ActionResult GetServiceTypeById(int id)
		{
			var values = _serviceManger.ServiceTypeService.GetById(id);
			var resultDtos = _mapper.Map<IEnumerable<ResultServiceTypeDto>>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateServiceType")]
		public ActionResult CreateServiceType(CreateServiceTypeDto createServiceTypeDto)
		{
			var values = _mapper.Map<ServiceType>(createServiceTypeDto);
			_serviceManger.ServiceTypeService.Add(values);
			return Ok("ServiceType added.");
		}

		[HttpDelete("DeleteServiceType/{id}")]
		public ActionResult DeleteServiceType(int id)
		{
			_serviceManger.ServiceTypeService.Delete(id);
			return Ok("ServiceType deleted.");
		}
		[HttpPut("UpdateServiceType")]
		public ActionResult UpdateServiceType(UpdateServiceTypeDto updateServiceTypeDto)
		{
			var values = _mapper.Map<ServiceType>(updateServiceTypeDto);
			_serviceManger.ServiceTypeService.Update(values);
			return Ok("ServiceType updated.");
		}	
	}
}
