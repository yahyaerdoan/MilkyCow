using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class WhyUsManager : IWhyUsService
    {
        private readonly IWhyUsDal _whyUsDal;

		public WhyUsManager(IWhyUsDal whyUsDal)
		{
			_whyUsDal = whyUsDal;
		}

		public void Add(WhyUs entity)
        {
            _whyUsDal.Add(entity);
        }

        public void Delete(int id)
        {
            _whyUsDal?.Delete(id);
        }

        public List<WhyUs> GetAll()
        {
            var values = _whyUsDal.GetAll();
            return values;
        }

        public WhyUs GetById(int id)
        {
            var values = _whyUsDal.GetById(id);
            return values;
        }

        public void Update(WhyUs entity)
        {
            _whyUsDal.Update(entity);
        }
    }
}
