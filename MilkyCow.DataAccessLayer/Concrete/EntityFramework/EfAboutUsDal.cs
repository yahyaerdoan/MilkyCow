using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfAboutUsDal : EfGenericRepository<AboutUs, MilkyCowDbContext>, IAboutUsDal
    {
        public EfAboutUsDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}
