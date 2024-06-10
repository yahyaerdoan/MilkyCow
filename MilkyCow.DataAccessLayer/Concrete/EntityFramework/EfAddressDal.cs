using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfAddressDal : EfGenericRepository<Address, MilkyCowDbContext>, IAddressDal
    {
        public EfAddressDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
