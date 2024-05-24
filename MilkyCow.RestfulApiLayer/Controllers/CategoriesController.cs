using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.DataTransferObjectLayer.Concrete.CategoryDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("CategoryList")]
        public IActionResult CategoryList()
        {
            var categories = _categoryService.GetAll();
            var categoryDtos = categories.Select(category => new ResultCategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
            }).ToList();
            return Ok(categoryDtos);
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.Add(new Category { Name = createCategoryDto.Name, Description = createCategoryDto.Description});
            return Ok("Category added.");
        }

        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return Ok("Category deleted.");
        }

        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.Update(new Category {CategoryId = updateCategoryDto.CategoryId, Name = updateCategoryDto.Name, Description = updateCategoryDto.Description });
            return Ok("Category updated.");
        }
        [HttpGet("GetCategory/{id}")]
        public IActionResult GetCategory(int id)
        {
            var values = _categoryService.GetById(id);
            return Ok(values);
        }
    }
}
