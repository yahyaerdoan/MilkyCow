using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.BusinessLayer.Abstact.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.AddressDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.BannerDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannersController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public BannersController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("BannerList")]
		public ActionResult BannersList()
		{
			var values = _serviceManger.BannerService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultBannerDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetBannerById/{id}")]
		public ActionResult GetBannerById(int id)
		{
			var values = _serviceManger.BannerService.GetById(id);
			var resultDtos = _mapper.Map<Banner,ResultBannerDto>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateBanner")]
		public ActionResult CreateBanner(CreateBannerDto createBannerDto)
		{
			var values = _mapper.Map<Banner>(createBannerDto);
			_serviceManger.BannerService.Add(values);
			return Ok("Banner added.");
		}

		[HttpDelete("DeleteBanner/{id}")]
		public ActionResult DeleteBanner(int id)
		{
			_serviceManger.BannerService.Delete(id);
			return Ok("Banner deleted.");
		}
		[HttpPut("UpdateBanner")]
		public ActionResult UpdateBanner(UpdateBannerDto updateBannerDto)
		{
			var values = _mapper.Map<Banner>(updateBannerDto);
			_serviceManger.BannerService.Update(values);
			return Ok("Banner updated.");
		}
	}
}
