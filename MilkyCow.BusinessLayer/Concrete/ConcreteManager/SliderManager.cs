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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void Add(Slider entity)
        {
            _sliderDal.Add(entity);
        }

        public void Delete(int id)
        {
            _sliderDal.Delete(id);
        }

        public List<Slider> GetAll()
        {
            return _sliderDal.GetAll();
        }

        public Slider GetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public void Update(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}
