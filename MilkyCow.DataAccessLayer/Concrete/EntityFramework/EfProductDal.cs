using Microsoft.EntityFrameworkCore;
using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.DataAccessLayer.Abstact.IGenericRepository;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductDal : EfGenericRepository<Product, MilkyCowDbContext>, IProductDal
    {
        public EfProductDal(MilkyCowDbContext context) : base(context)
        {           
        }

        public List<Product> GetProductWithCategory()
        {
            var values =  _context.Products.Include(x=> x.Category).ToList();
            return values;
        }

        public int GetProductCount()
        {
            var values = _context.Products.Count();
            return values;
        }
    }
}