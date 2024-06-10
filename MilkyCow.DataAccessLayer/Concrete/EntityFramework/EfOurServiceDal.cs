using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfOurServiceDal : EfGenericRepository<OurService, MilkyCowDbContext>, IOurServiceDal
    {
        public EfOurServiceDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
