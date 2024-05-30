using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.AboutUsDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
	[Area("MilkyAdmin")]
	[Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
	public class AboutUsController : Controller
	{
		private readonly DynamicConsume<ResultAboutUsDto> _resultAboutUsDto;
		private readonly DynamicConsume<CreateAboutUsDto> _createAboutUsDto;
		private readonly DynamicConsume<UpdateAboutUsDto> _updateAboutUsDto;
		private readonly DynamicConsume<object> _object;


		public AboutUsController(DynamicConsume<ResultAboutUsDto> resultAboutUsDto, DynamicConsume<CreateAboutUsDto> createAboutUsDto, DynamicConsume<UpdateAboutUsDto> updateAboutUsDto, DynamicConsume<object> oobject)
		{
			_resultAboutUsDto = resultAboutUsDto;
			_createAboutUsDto = createAboutUsDto;
			_updateAboutUsDto = updateAboutUsDto;
			_object = oobject;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _resultAboutUsDto.GetListAsync("AboutUs/AboutUsList");
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateAboutUs()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> CreateAboutUs(CreateAboutUsDto createAboutUsDto)
		{
			var values = await _createAboutUsDto.PostAsync("AboutUs/CreateAboutUs", createAboutUsDto);
			if (values > 0)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateAboutUs(int id)
		{
			var values = await _updateAboutUsDto.GetByIdAsync("AboutUs/GetAboutUsById", id);
			return View(values);
		}


		[HttpPost]
		public async Task<IActionResult> UpdateAboutUs(UpdateAboutUsDto updateAboutUsDto)
		{
			var values = await _createAboutUsDto.PutAsync("AboutUs/UpdateAboutUs", updateAboutUsDto);
			if (values > 0)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteAboutUs(int id)
		{
			var values = await _object.DeleteAsync("AboutUs/DeleteAboutUs", id);
			if (values > 0)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
