using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class BannerManager : IBannerService
    {
        private readonly IBannerDal _bannerDal;

		public BannerManager(IBannerDal bannerDal)
		{
			_bannerDal = bannerDal;
		}

		public void Add(Banner entity)
        {
            _bannerDal.Add(entity);
        }

        public void Delete(int id)
        {
            _bannerDal.Delete(id);
        }

        public List<Banner> GetAll()
        {
            var values = _bannerDal.GetAll();
            return values;
        }

        public Banner GetById(int id)
        {
            var values = _bannerDal.GetById(id);
            return values;
        }

        public void Update(Banner entity)
        {
            _bannerDal.Update(entity);
        }
    }
}
