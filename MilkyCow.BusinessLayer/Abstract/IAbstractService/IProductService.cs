using MilkyCow.BusinessLayer.Abstract.IGenericService;
using MilkyCow.DataTransferObjectLayer.Concrete.ProductDtos;
using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.BusinessLayer.Abstract.IAbstractService
{
    public interface IProductService : IGenericService<Product>
    {
        string CreateProduct(CreateProductDto createProductDto);
        List<Product> GetProductWithCategory();
        int GetProductCount();
    }
}