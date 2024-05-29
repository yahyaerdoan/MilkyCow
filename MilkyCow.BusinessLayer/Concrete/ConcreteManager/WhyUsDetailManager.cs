using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class WhyUsDetailManager : IWhyUsDetailService
    {
        private readonly IWhyUsDetailDal _whyUsDetailDal;

		public WhyUsDetailManager(IWhyUsDetailDal whyUsDetailDal)
		{
			_whyUsDetailDal = whyUsDetailDal;
		}

		public void Add(WhyUsDetail entity)
        {
            _whyUsDetailDal.Add(entity);
        }

        public void Delete(int id)
        {
            _whyUsDetailDal.Delete(id);
        }

        public List<WhyUsDetail> GetAll()
        {
            var values = _whyUsDetailDal.GetAll();
            return values;
        }

        public WhyUsDetail GetById(int id)
        {
            var values =  _whyUsDetailDal.GetById(id);
            return values;
        }

        public void Update(WhyUsDetail entity)
        {
            _whyUsDetailDal.Update(entity);
        }
    }
}
