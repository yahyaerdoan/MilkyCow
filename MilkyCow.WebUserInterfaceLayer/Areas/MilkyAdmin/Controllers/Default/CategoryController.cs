using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.CategoryDtos;
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
            var values = await _resultCategoryDto.GetListAsync("Categories/CategoryList");
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
            var values = await _createCategoryDto.PostAsync("Categories/CreateCategory", createCategoryDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var values = await _updateCategoryDto.GetByIdAsync("Categories/GetCategory", id);            
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var values = await _createCategoryDto.PutAsync("Categories/UpdateCategory", updateCategoryDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

 
        public async Task<IActionResult> DeleteCategory(int id)
        {
          var values = await _object.DeleteAsync("Categories/DeleteCategory", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
