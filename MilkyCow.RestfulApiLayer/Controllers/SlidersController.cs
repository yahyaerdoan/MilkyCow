using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using MilkyCow.BusinessLayer.Abstract.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.SliderDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public SlidersController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("SliderList")]
		public ActionResult SliderList()
		{
			var values = _serviceManger.SliderService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultSliderDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetSliderById/{id}")]
		public ActionResult GetSliderById(int id)
		{
			var values = _serviceManger.SliderService.GetById(id);
			var resultDtos = _mapper.Map<Slider, ResultSliderDto>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateSlider")]
		public ActionResult CreateBanner(CreateSliderDto createSliderDto)
		{
			var values = _mapper.Map<Slider>(createSliderDto);
			_serviceManger.SliderService.Add(values);
			return Ok("Slider added.");
		}

		[HttpDelete("DeleteSlider/{id}")]
		public ActionResult DeleteSlider(int id)
		{
			_serviceManger.SliderService.Delete(id);
			return Ok("Slider deleted.");
		}
		[HttpPut("UpdateSlider")]
		public ActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
		{
			var values = _mapper.Map<Slider>(updateSliderDto);
			_serviceManger.SliderService.Update(values);
			return Ok("Slider updated.");
		}
	}
}
