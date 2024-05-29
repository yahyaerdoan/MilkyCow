using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class BusinessHourManager : IBusinessHourService
    {
        private readonly IBusinessHourDal _businessHourDal;

		public BusinessHourManager(IBusinessHourDal businessHourDal)
		{
			_businessHourDal = businessHourDal;
		}

		public void Add(BusinessHour entity)
        {
            _businessHourDal.Add(entity);
        }

        public void Delete(int id)
        {
            _businessHourDal.Delete(id);
        }

        public List<BusinessHour> GetAll()
        {
            var values = _businessHourDal.GetAll();
            return values;
        }

        public BusinessHour GetById(int id)
        {
            var values = _businessHourDal.GetById(id);
            return values;
        }

        public void Update(BusinessHour entity)
        {
            _businessHourDal.Update(entity);
        }
    }
}
