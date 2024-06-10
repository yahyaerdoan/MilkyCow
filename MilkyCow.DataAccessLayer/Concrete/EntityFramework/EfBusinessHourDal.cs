using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfBusinessHourDal : EfGenericRepository<BusinessHour, MilkyCowDbContext>, IBusinessHourDal
    {
        public EfBusinessHourDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
