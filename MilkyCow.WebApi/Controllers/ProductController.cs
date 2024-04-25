using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult ProductList()
        {
            var values = _productService.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product )
        {
           _productService.Add(product);
            return Ok("Product added.");
        }
        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            _productService.Delete(id);
            return Ok("Poduct deleted.");
        }
        [HttpPut]
        public ActionResult UpdateProduct(Product product)
        {
            _productService.Update(product);
            return Ok("Poduct updated.");
        }

        [HttpGet("Product/GetById")]
        public ActionResult GetProductById(int id)
        {
           var values =  _productService.GetById(id);
            return Ok(values);
        }
    }
}
