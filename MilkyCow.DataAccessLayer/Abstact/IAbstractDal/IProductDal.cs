using MilkyCow.DataAccessLayer.Abstact.IGenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Abstact.IAbstractDal
{
    public interface IProductDal : IGenericRepository<Product>
    {
        List<Product> GetProductWithCategory();
        int GetProductCount();
    }
}
