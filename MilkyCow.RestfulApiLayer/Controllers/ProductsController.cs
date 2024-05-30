using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.BusinessLayer.Abstact.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.ProductDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public ProductsController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("ProductList")]
		public ActionResult ProductList()
		{
			var values = _serviceManger.ProductService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultProductDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetProductById/{id}")]
		public ActionResult GetProductById(int id)
		{
			var values = _serviceManger.ProductService.GetById(id);
			var resultDtos = _mapper.Map<Product, ResultProductDto>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateProduct")]
		public ActionResult CreateBanner(CreateProductDto createProductDto)
		{
			var values = _mapper.Map<Product>(createProductDto);
			_serviceManger.ProductService.Add(values);
			return Ok("Product added.");
		}

		[HttpDelete("DeleteProduct/{id}")]
		public ActionResult DeleteProduct(int id)
		{
			_serviceManger.ProductService.Delete(id);
			return Ok("Product deleted.");
		}
		[HttpPut("UpdateProduct")]
		public ActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			var values = _mapper.Map<Product>(updateProductDto);
			_serviceManger.ProductService.Update(values);
			return Ok("Product updated.");
		}

		[HttpGet("GetProductWithCategory")]
        public ActionResult GetProductWithCategory()
        {
            var values = _serviceManger.ProductService.GetProductWithCategory();
			var resultDtos = _mapper.Map<IEnumerable<ResultProductDto>>(values);
			return Ok(resultDtos);
        }

        [HttpGet("GetProductCount")]
        public ActionResult GetProducCount()
        {
            var values = _serviceManger.ProductService.GetProductCount();
            return Ok(values);
        }
    }
}
