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
        public DbSet<AboutUs> AboutUses { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<BusinessHour> BusinessHours { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<OurService> OurServices { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamMemberSocialMedia> TeamMemberSocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<WhyUs> WhyUses { get; set; }
        public DbSet<WhyUsDetail> WhyUsDetails { get; set; }
    }
}