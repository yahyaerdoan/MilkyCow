using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.TestimonialDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialsController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public TestimonialsController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("TestimonialList")]
		public ActionResult TestimonialList()
		{
			var values = _serviceManger.TestimonialService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultTestimonialDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetTestimonialById/{id}")]
		public ActionResult GetTestimonialById(int id)
		{
			var values = _serviceManger.TestimonialService.GetById(id);
			var resultDtos = _mapper.Map<Testimonial,ResultTestimonialDto>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateTestimonial")]
		public ActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			var values = _mapper.Map<Testimonial>(createTestimonialDto);
			_serviceManger.TestimonialService.Add(values);
			return Ok("Testimonial added.");
		}

		[HttpDelete("DeleteTestimonial/{id}")]
		public ActionResult DeleteTestimonial(int id)
		{
			_serviceManger.TestimonialService.Delete(id);
			return Ok("Testimonial deleted.");
		}
		[HttpPut("UpdateTestimonial")]
		public ActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			var values = _mapper.Map<Testimonial>(updateTestimonialDto);
			_serviceManger.TestimonialService.Update(values);
			return Ok("Testimonial updated.");
		}
	}
}
