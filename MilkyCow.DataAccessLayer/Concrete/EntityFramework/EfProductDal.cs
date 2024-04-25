﻿using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.DataAccessLayer.Abstact.IGenericRepository;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductDal : EfGenericRepository<Product, MilkyCowDbContext>, IProductDal
    {
        public EfProductDal(MilkyCowDbContext context) : base(context)
        {
        }
    }
}