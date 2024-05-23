using Microsoft.AspNetCore.Mvc;
using MilkyCow.WebUserInterfaceLayer.Dtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;
using Newtonsoft.Json.Linq;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class CategoryController : Controller
    {
        private readonly DynamicConsume<ResultCategoryDto> _resultCategoryDto;
        private readonly DynamicConsume<CreateCategoryDto> _createCategoryDto;
        private readonly DynamicConsume<UpdateCategoryDto> _updateCategoryDto;
        private readonly DynamicConsume<object> _object;


        public CategoryController(DynamicConsume<ResultCategoryDto> resultCategoryDto, DynamicConsume<CreateCategoryDto> createCategoryDto, DynamicConsume<UpdateCategoryDto> updateCategoryDto, DynamicConsume<object> oobject)
        {
            _resultCategoryDto = resultCategoryDto;
            _createCategoryDto = createCategoryDto;
            _updateCategoryDto = updateCategoryDto;
            _object = oobject;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _resultCategoryDto.GetListAsync("Category/CategoryList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var values = await _createCategoryDto.PostAsync("Category/CreateCategory", createCategoryDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var values = await _updateCategoryDto.GetByIdAsync("Category/GetCategory",id);            
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var values = await _createCategoryDto.PutAsync("Category/UpdateCategory", updateCategoryDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

 
        public async Task<IActionResult> DeleteCategory(int id)
        {
          var values = await _object.DeleteAsync("Category/DeleteCategory", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
