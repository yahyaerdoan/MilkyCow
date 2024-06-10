using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

		public TestimonialManager(ITestimonialDal testimonialDal)
		{
			_testimonialDal = testimonialDal;
		}

		public void Add(Testimonial entity)
        {
            _testimonialDal.Add(entity);
        }

        public void Delete(int id)
        {
            _testimonialDal.Delete(id);
        }

        public List<Testimonial> GetAll()
        {
            var values = _testimonialDal.GetAll();
            return values;
        }

        public Testimonial GetById(int id)
        {
            var values = _testimonialDal.GetById(id);
            return values;
        }

        public void Update(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
