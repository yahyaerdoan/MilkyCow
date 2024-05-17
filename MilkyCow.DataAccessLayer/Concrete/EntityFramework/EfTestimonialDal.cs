using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfTestimonialDal : EfGenericRepository<Testimonial, MilkyCowDbContext>, ITestimonialDal
    {
        public EfTestimonialDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
