using MilkyCow.DataAccessLayer.Abstract.IGenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Abstract.IAbstractDal
{
    public interface IProductDal : IGenericRepository<Product>
    {
        List<Product> GetProductWithCategory();
        int GetProductCount();
    }
}
