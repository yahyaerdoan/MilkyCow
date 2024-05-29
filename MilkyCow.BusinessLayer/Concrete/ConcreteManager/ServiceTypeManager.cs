using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class ServiceTypeManager : IServiceTypeService
    {
        private readonly IServiceTypeDal _serviceypeDal;

		public ServiceTypeManager(IServiceTypeDal serviceypeDal)
		{
			_serviceypeDal = serviceypeDal;
		}

		public void Add(ServiceType entity)
        {
            _serviceypeDal.Add(entity);
        }

        public void Delete(int id)
        {
            _serviceypeDal.Delete(id);
        }

        public List<ServiceType> GetAll()
        {
           var values = _serviceypeDal.GetAll();
            return values;
        }

        public ServiceType GetById(int id)
        {
            var values = _serviceypeDal.GetById(id);
            return values;
        }

        public void Update(ServiceType entity)
        {
            _serviceypeDal.Update(entity);
        }
    }
}
