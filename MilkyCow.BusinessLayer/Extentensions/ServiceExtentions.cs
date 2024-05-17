using Microsoft.Extensions.DependencyInjection;
using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.BusinessLayer.Concrete.ConcreteManager;
using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.BusinessLayer.Extentensions
{
    public static class ServiceExtensions
    {
        public static void ContainerDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAboutUsDal, EfAboutUsDal>();
            services.AddScoped<IAboutUsService, AboutUsManager>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDal, EfSliderDal>();
        }
    }
}
