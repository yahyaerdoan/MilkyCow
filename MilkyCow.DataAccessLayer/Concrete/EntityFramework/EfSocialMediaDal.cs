using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfSocialMediaDal : EfGenericRepository<SocialMedia, MilkyCowDbContext>, ISocialMediaDal
    {
        public EfSocialMediaDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
