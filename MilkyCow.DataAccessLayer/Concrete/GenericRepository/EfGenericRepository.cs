using Microsoft.EntityFrameworkCore;
using MilkyCow.DataAccessLayer.Abstract.IGenericRepository;
using MilkyCow.DataAccessLayer.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MilkyCow.DataAccessLayer.Concrete.GenericRepository
{
    public class EfGenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class, new() 
        where TContext : DbContext, new()
    {
        protected readonly MilkyCowDbContext _context;
        protected readonly DbSet<TEntity> _set;

        public EfGenericRepository(MilkyCowDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var values = _set.Find(id);
            _set.Remove(values);
            _context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return _set.ToList();
        }

        public TEntity GetById(int id)
        {
           return _set.Find(id);
        }

        public void Update(TEntity entity)
        {
           _set.Update(entity);
            _context.SaveChanges();
        }
    }
}