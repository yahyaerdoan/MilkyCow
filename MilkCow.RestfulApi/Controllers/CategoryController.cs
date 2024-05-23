using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("Categories/list")]
        public IActionResult CategoryList()
        {
            var values = _categoryService.GetAll();
            return Ok(values);
        }

        [HttpPost("Category/Create")]
        public IActionResult CreateCategory(Category category)
        {
             _categoryService.Add(category);
            return Ok("Category added.");
        }

        [HttpDelete("Category/Delete")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return Ok("Category deleted.");
        }

        [HttpPut("Category/Update")]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.Update(category);
            return Ok("Category updated.");
        }
        [HttpGet("Category/GetById")]
        public IActionResult GetCategory(int id)
        {
           var values = _categoryService.GetById(id);
            return Ok(values);
        }
    }
}