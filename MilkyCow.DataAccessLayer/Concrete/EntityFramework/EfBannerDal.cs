using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfBannerDal : EfGenericRepository<Banner, MilkyCowDbContext>, IBannerDal
    {
        public EfBannerDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
