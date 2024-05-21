using Microsoft.AspNetCore.Mvc;
using MilkyCow.WebUserInterfaceLayer.Dtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class CategoryController : Controller
    {
        private readonly DynamicConsume<ResultCategoryDto> _resultCategoryDto;

        public CategoryController(DynamicConsume<ResultCategoryDto> resultCategoryDto)
        {
            _resultCategoryDto = resultCategoryDto;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _resultCategoryDto.GetListAsync("Category/Categories/list");
            return View(values);
        }
    }
}
