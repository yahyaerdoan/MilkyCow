using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.DataTransferObjectLayer.Concrete.AboutUsDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutUsController : ControllerBase
	{
		private readonly IAboutUsService _aboutUsService;
		private readonly IMapper _mapper;

		public AboutUsController(IAboutUsService aboutUsService, IMapper mapper)
		{
			_aboutUsService = aboutUsService;
			_mapper = mapper;
		}
		[HttpGet("AboutUsList")]
		public ActionResult AboutUsList()
		{
			var values = _aboutUsService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultAboutUsDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetAboutUsById/{id}")]
		public ActionResult<IEnumerable<ResultAboutUsDto>> GetAboutUsById(int id)
		{
			var aboutUs = _aboutUsService.GetById(id);
			if (aboutUs == null)
			{
				return NotFound();
			}
			var aboutUsDto = _mapper.Map<AboutUs,ResultAboutUsDto>(aboutUs);
			return Ok(aboutUsDto);
		}

		[HttpPost("CreateAboutUs")]
		public ActionResult CreateAboutUs(CreateAboutUsDto createAboutUsDto)
		{
			var values = _mapper.Map<AboutUs>(createAboutUsDto);
			_aboutUsService.Add(values);
			return Ok("About Us added.");
		}

		[HttpDelete("DeleteAboutUs/{id}")]
		public ActionResult DeleteAboutUs(int id)
		{
			_aboutUsService.Delete(id);
			return Ok("About Us deleted.");
		}
		[HttpPut("UpdateAboutUs")]
		public ActionResult UpdateAboutUs(UpdateAboutUsDto updateAboutUsDto)
		{
			var values = _mapper.Map<AboutUs>(updateAboutUsDto);
			_aboutUsService.Update(values);
			return Ok("About Us updated.");
		}
	}
}
