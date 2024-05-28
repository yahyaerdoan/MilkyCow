using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;

		public AddressManager(IAddressDal addressDal)
		{
			_addressDal = addressDal;
		}

		public void Add(Address entity)
        {
            _addressDal.Add(entity);
        }

        public void Delete(int id)
        {
            _addressDal.Delete(id);
        }

        public List<Address> GetAll()
        {
            var values = _addressDal.GetAll();
            return values;
        }

        public Address GetById(int id)
        {
            var values = _addressDal.GetById(id);
            return values;
        }

        public void Update(Address entity)
        {
            _addressDal.Update(entity);
        }
    }
}
