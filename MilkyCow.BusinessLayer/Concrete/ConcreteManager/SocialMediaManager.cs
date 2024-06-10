using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

		public SocialMediaManager(ISocialMediaDal socialMediaDal)
		{
			_socialMediaDal = socialMediaDal;
		}

		public void Add(SocialMedia entity)
        {
			_socialMediaDal.Add(entity);
        }

        public void Delete(int id)
        {
			_socialMediaDal.Delete(id);
        }

        public List<SocialMedia> GetAll()
        {
            var values = _socialMediaDal.GetAll();
            return values;
        }

        public SocialMedia GetById(int id)
        {
            var values = _socialMediaDal.GetById(id);
            return values;
        }

        public void Update(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}
