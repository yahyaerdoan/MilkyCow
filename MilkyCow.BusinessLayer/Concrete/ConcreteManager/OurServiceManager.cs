using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class OurServiceManager : IOurServiceService
    {
        private readonly IOurServiceDal _serviceDal;

		public OurServiceManager(IOurServiceDal serviceDal)
		{
			_serviceDal = serviceDal;
		}

		public void Add(OurService entity)
        {
            _serviceDal.Add(entity);
        }

        public void Delete(int id)
        {
            _serviceDal.Delete(id);
        }

        public List<OurService> GetAll()
        {
            var values = _serviceDal.GetAll();
            return values;
        }

        public OurService GetById(int id)
        {
			var values = _serviceDal.GetById(id);
			return values;
		}

        public void Update(OurService entity)
        {
            _serviceDal.Update(entity);
        }
    }
}
