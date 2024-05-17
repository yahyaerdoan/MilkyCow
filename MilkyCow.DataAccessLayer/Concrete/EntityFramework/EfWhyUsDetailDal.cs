using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfWhyUsDetailDal : EfGenericRepository<WhyUsDetail, MilkyCowDbContext>, IWhyUsDetailDal
    {
        public EfWhyUsDetailDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
