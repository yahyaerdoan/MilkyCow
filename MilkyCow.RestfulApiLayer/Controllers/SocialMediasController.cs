using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstract.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.SocialMediaDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediasController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public SocialMediasController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("SocialMediaList")]
		public ActionResult SocialMediaList()
		{
			var values = _serviceManger.SocialMediaService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultSocialMediaDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetSocialMediaById/{id}")]
		public ActionResult GetSocialMediaById(int id)
		{
			var values = _serviceManger.SocialMediaService.GetById(id);
			var resultDtos = _mapper.Map<SocialMedia,ResultSocialMediaDto>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateSocialMedia")]
		public ActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
		{
			var values = _mapper.Map<SocialMedia>(createSocialMediaDto);
			_serviceManger.SocialMediaService.Add(values);
			return Ok("SocialMedia added.");
		}

		[HttpDelete("DeleteSocialMedia/{id}")]
		public ActionResult DeleteSocialMedia(int id)
		{
			_serviceManger.SocialMediaService.Delete(id);
			return Ok("SocialMedia deleted.");
		}
		[HttpPut("UpdateSocialMedia")]
		public ActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
		{
			var values = _mapper.Map<SocialMedia>(updateSocialMediaDto);
			_serviceManger.SocialMediaService.Update(values);
			return Ok("SocialMedia updated.");
		}
	}
}
