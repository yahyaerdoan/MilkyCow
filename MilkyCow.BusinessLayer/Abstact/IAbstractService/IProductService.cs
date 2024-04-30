using MilkyCow.BusinessLayer.Abstact.IGenericService;
using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.BusinessLayer.Abstact.IAbstractService
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetProductWithCategory();
    }
}