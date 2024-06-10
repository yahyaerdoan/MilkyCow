using MilkyCow.DataAccessLayer.Abstract.IGenericRepository;
using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataAccessLayer.Abstract.IAbstractDal
{
    public interface ICategoryDal : IGenericRepository<Category>
    {
    }
}
