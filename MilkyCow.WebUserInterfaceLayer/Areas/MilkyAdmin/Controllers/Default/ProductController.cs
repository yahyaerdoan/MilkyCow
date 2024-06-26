﻿using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.CategoryDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.ProductDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class ProductController : Controller
    {       
        private readonly DynamicConsume<ResultProductDto> _resultProductDto;
        private readonly DynamicConsume<CreateProductDto> _createProductDto;
        private readonly DynamicConsume<UpdateProductDto> _updateProductDto;
        private readonly DynamicConsume<object> _object;

        private readonly DynamicConsume<ResultCategoryDto> _resultCategoryDto;

        public ProductController(DynamicConsume<ResultProductDto> resultProductDto, DynamicConsume<CreateProductDto> createProductDto, DynamicConsume<UpdateProductDto> updateProductDto, DynamicConsume<object> oobject, DynamicConsume<ResultCategoryDto> resultCategoryDto)
        {
            _resultProductDto = resultProductDto;
            _createProductDto = createProductDto;
            _updateProductDto = updateProductDto;
            _object = oobject;
            _resultCategoryDto = resultCategoryDto;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _resultProductDto.GetListAsync("Products/GetProductsWithCategory");
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _resultCategoryDto.GetListAsync("Categories/CategoryList");
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var values = await _createProductDto.PostAsync("Products/CreateProduct", createProductDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var categories = await _resultCategoryDto.GetListAsync("Categories/CategoryList");
            ViewBag.Categories = categories;
            var values = await _updateProductDto.GetByIdAsync("Products/GetProductById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = await _createProductDto.PutAsync("Products/UpdateProduct", updateProductDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var values = await _object.DeleteAsync("Products/DeleteProduct", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    } 
}
