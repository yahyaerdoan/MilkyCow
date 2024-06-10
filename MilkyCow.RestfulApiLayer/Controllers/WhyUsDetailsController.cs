using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstract.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.WhyUsDetailDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WhyUsDetailsController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public WhyUsDetailsController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("WhyUsDetailList")]
		public ActionResult WhyUsDetailList()
		{
			var values = _serviceManger.WhyUsDetailService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultWhyUsDetailDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetWhyUsDetailById/{id}")]
		public ActionResult GetWhyUsDetailById(int id)
		{
			var values = _serviceManger.WhyUsDetailService.GetById(id);
			var resultDtos = _mapper.Map<WhyUsDetail,ResultWhyUsDetailDto>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateWhyUsDetail")]
		public ActionResult CreateWhyUsDetail(CreateWhyUsDetailDto createWhyUsDetailDto)
		{
			var values = _mapper.Map<WhyUsDetail>(createWhyUsDetailDto);
			_serviceManger.WhyUsDetailService.Add(values);
			return Ok("WhyUsDetail added.");
		}

		[HttpDelete("DeleteWhyUsDetail/{id}")]
		public ActionResult DeleteWhyUsDetail(int id)
		{
			_serviceManger.WhyUsDetailService.Delete(id);
			return Ok("WhyUsDetail deleted.");
		}
		[HttpPut("UpdateWhyUsDetail")]
		public ActionResult UpdateWhyUsDetail(UpdateWhyUsDetailDto updateWhyUsDetailDto)
		{
			var values = _mapper.Map<WhyUsDetail>(updateWhyUsDetailDto);
			_serviceManger.WhyUsDetailService.Update(values);
			return Ok("WhyUsDetail updated.");
		}
	}
}
