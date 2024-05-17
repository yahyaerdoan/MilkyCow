using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Delete(int id)
        {
            _categoryDal.Delete(id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}