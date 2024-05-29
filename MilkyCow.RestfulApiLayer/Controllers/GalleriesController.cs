using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.GalleryDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GalleriesController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public GalleriesController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("GalleriesList")]
		public ActionResult GalleriesList()
		{
			var values = _serviceManger.GalleryService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultGalleryDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetGalleryById/{id}")]
		public ActionResult GetGalleryById(int id)
		{
			var values = _serviceManger.GalleryService.GetById(id);
			var resultDtos = _mapper.Map<IEnumerable<ResultGalleryDto>>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateGallery")]
		public ActionResult CreateBanner(CreateGalleryDto createGalleryDto)
		{
			var values = _mapper.Map<Gallery>(createGalleryDto);
			_serviceManger.GalleryService.Add(values);
			return Ok("Gallery added.");
		}

		[HttpDelete("DeleteGallery/{id}")]
		public ActionResult DeleteGallery(int id)
		{
			_serviceManger.GalleryService.Delete(id);
			return Ok("Gallery deleted.");
		}
		[HttpPut("UpdateGallery")]
		public ActionResult UpdateGallery(UpdateGalleryDto updateGalleryDto)
		{
			var values = _mapper.Map<Gallery>(updateGalleryDto);
			_serviceManger.GalleryService.Update(values);
			return Ok("Gallery updated.");
		}
	}
}
