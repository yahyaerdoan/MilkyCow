﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataAccessLayer.Abstact.IGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        List<TEntity> GetAll();
        TEntity GetById(int id);
    }
}