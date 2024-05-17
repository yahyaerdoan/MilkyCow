using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfWhyUsDal : EfGenericRepository<WhyUs, MilkyCowDbContext>, IWhyUsDal
    {
        public EfWhyUsDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
