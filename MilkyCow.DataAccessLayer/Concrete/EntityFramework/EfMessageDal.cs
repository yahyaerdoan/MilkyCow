using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessageDal : EfGenericRepository<Message, MilkyCowDbContext>, IMessageDal
    {
        public EfMessageDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
