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

            services.AddScoped<IAddressDal, EfAddressDal>();
            services.AddScoped<IAddressService, AddressManager>();

            services.AddScoped<IBannerDal, EfBannerDal>();
            services.AddScoped<IBannerService, BannerManager>();

            services.AddScoped<IBusinessHourDal, EfBusinessHourDal>();
            services.AddScoped<IBusinessHourService, BusinessHourManager>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IGalleryDal, EfGalleryDal>();
            services.AddScoped<IGalleryService, GalleryManager>();

            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();

            services.AddScoped<IOurServiceDal, EfOurServiceDal>();
            services.AddScoped<IOurServiceService, OurServiceManager>();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IServiceTypeDal, EfServiceTypeDal>();
            services.AddScoped<IServiceTypeService, ServiceTypeManager>();

            services.AddScoped<ISliderDal, EfSliderDal>();
            services.AddScoped<ISliderService, SliderManager>();        

            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();

            services.AddScoped<ITeamMemberDal, EfTeamMemberDal>();
            services.AddScoped<ITeamMemberService, TeamMemberManager>();

            services.AddScoped<ITeamMemberSocialMediaDal, EfTeamMemberSocialMediaDal>();
            services.AddScoped<ITeamMemberSocialMediaService, TeamMemberSocialMediaManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IWhyUsDal, EfWhyUsDal>();
            services.AddScoped<IWhyUsService, WhyUsManager>();

            services.AddScoped<IWhyUsDetailDal, EfWhyUsDetailDal>();
            services.AddScoped<IWhyUsDetailService, WhyUsDetailManager>();
        }
    }
}
