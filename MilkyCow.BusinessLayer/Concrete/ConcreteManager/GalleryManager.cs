using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class GalleryManager : IGalleryService
    {
        private readonly IGalleryDal _galleryDal;

		public GalleryManager(IGalleryDal galleryDal)
		{
			_galleryDal = galleryDal;
		}

		public void Add(Gallery entity)
        {
            _galleryDal.Add(entity);
        }

        public void Delete(int id)
        {
            _galleryDal.Delete(id);
        }

        public List<Gallery> GetAll()
        {
            var values = _galleryDal.GetAll();
            return values;
        }

        public Gallery GetById(int id)
        {
            var values = _galleryDal.GetById(id);
            return values;
        }

        public void Update(Gallery entity)
        {
            _galleryDal.Update(entity);
        }
    }
}
