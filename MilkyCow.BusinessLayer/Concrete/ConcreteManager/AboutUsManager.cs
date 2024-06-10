using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class AboutUsManager : IAboutUsService
    {
        private readonly IAboutUsDal _aboutUsDal;

		public AboutUsManager(IAboutUsDal aboutUsDal)
		{
			_aboutUsDal = aboutUsDal;
		}

		public void Add(AboutUs entity)
        {
            _aboutUsDal.Add(entity);
        }

        public void Delete(int id)
        {
            _aboutUsDal.Delete(id);
        }

        public List<AboutUs> GetAll()
        {
            var values = _aboutUsDal.GetAll();  
            return values;
        }

        public AboutUs GetById(int id)
        {
            var values = _aboutUsDal.GetById(id);
            return values;
        }

        public void Update(AboutUs entity)
        {
            _aboutUsDal.Update(entity);
        }
    }
}
