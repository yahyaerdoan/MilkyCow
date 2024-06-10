using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.DataAccessLayer.Abstract.IGenericRepository;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfCategoryDal : EfGenericRepository<Category, MilkyCowDbContext>, ICategoryDal
    {
        public EfCategoryDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
