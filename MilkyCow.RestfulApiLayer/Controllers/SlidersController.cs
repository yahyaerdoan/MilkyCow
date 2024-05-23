using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IAbstractService;

namespace MilkyCow.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpGet("GetAllSliders")]
        public IActionResult GetAllSliders()
        {
            var result = _sliderService.GetAll();
            if (result == null || result.Count == 0)
            {
                return NotFound($"Data does not exist yet.");
            }
            return Ok(result);
        }
    }
}
