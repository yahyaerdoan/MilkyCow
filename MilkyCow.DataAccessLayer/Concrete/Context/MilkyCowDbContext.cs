using Microsoft.EntityFrameworkCore;
using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataAccessLayer.Concrete.Context
{
    public class MilkyCowDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YAHYAERDOGAN; initial catalog=MilkyCowDb; integrated security=true;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}