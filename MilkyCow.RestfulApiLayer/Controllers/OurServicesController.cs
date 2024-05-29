using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.OurServiceDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OurServicesController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public OurServicesController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("OurServicesList")]
		public ActionResult OurServicesList()
		{
			var values = _serviceManger.OurService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultOurServiceDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetOurServiceById/{id}")]
		public ActionResult GetOurServiceById(int id)
		{
			var values = _serviceManger.OurService.GetById(id);
			var resultDtos = _mapper.Map<OurService,ResultOurServiceDto>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateOurService")]
		public ActionResult CreateOurService(CreateOurServiceDto createOurServiceDto)
		{
			var values = _mapper.Map<OurService>(createOurServiceDto);		
			_serviceManger.OurService.Add(values);
			return Ok("OurService added.");
		}

		[HttpDelete("DeleteOurService/{id}")]
		public ActionResult DeleteOurService(int id)
		{
			_serviceManger.OurService.Delete(id);
			return Ok("OurService deleted.");
		}
		[HttpPut("UpdateOurService")]
		public ActionResult UpdateOurService(UpdateOurServiceDto updateOurServiceDto)
		{
			var values = _mapper.Map<OurService>(updateOurServiceDto);
			_serviceManger.OurService.Update(values);
			return Ok("OurService updated.");
		}
	}
}
