﻿using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.BusinessLayer.Abstract.IServiceManager
{
    public interface IServiceManager
    {
        IAboutUsService AboutUsService { get; }
        IAddressService AddressService { get; }
        IBannerService BannerService { get; }
        IBusinessHourService BusinessHourService { get; }
        ICategoryService CategoryService { get; }
        IGalleryService GalleryService { get; }
        IMessageService MessageService { get; }
        IOurServiceService OurService { get; }
        IProductService ProductService { get; }
        IServiceTypeService ServiceTypeService { get; }
        ISliderService SliderService { get; }
        ISocialMediaService SocialMediaService { get; }
        ITeamMemberService TeamMemberService { get; }
        ITeamMemberSocialMediaService TeamMemberSocialMediaService { get; }
        ITestimonialService TestimonialService { get; }
        IWhyUsDetailService WhyUsDetailService { get; }
        IWhyUsService WhyUsService { get; }
    }
}
