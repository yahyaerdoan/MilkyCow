using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using MilkyCow.BusinessLayer.Abstract.IServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.BusinessLayer.Concrete.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly IAddressService  _addressService;
        private readonly IBannerService  _bannerService;
        private readonly IBusinessHourService _businessHourService;
        private readonly ICategoryService _categoryService;
        private readonly IGalleryService _galleryService;
        private readonly IMessageService _messageService;
        private readonly IOurServiceService _ourServiceService;
        private readonly IProductService _productService;
        private readonly IServiceTypeService _serviceTypeService;
        private readonly ISliderService _sliderService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly ITeamMemberService _teamMemberService;
        private readonly ITeamMemberSocialMediaService _teamMeberSocialMediaService;
        private readonly ITestimonialService _testimonialService;
        private readonly IWhyUsService _whyUsService;
        private readonly IWhyUsDetailService _whyUsDetailService;

        public ServiceManager(IAboutUsService aboutUsService, IAddressService addressService, IBannerService bannerService, IBusinessHourService businessHourService, ICategoryService categoryService, IGalleryService galleryService, IMessageService messageService, IOurServiceService ourServiceService, IProductService productService, IServiceTypeService serviceTypeService, ISliderService sliderService, ISocialMediaService socialMediaService, ITeamMemberService teamMemberService, ITeamMemberSocialMediaService teamMeberSocialMediaService, ITestimonialService testimonialService, IWhyUsService whyUsService, IWhyUsDetailService whyUsDetailService)
        {
            _aboutUsService = aboutUsService;
            _addressService = addressService;
            _bannerService = bannerService;
            _businessHourService = businessHourService;
            _categoryService = categoryService;
            _galleryService = galleryService;
            _messageService = messageService;
            _ourServiceService = ourServiceService;
            _productService = productService;
            _serviceTypeService = serviceTypeService;
            _sliderService = sliderService;
            _socialMediaService = socialMediaService;
            _teamMemberService = teamMemberService;
            _teamMeberSocialMediaService = teamMeberSocialMediaService;
            _testimonialService = testimonialService;
            _whyUsService = whyUsService;
            _whyUsDetailService = whyUsDetailService;
        }

        public IAboutUsService AboutUsService => _aboutUsService;

        public IAddressService AddressService => _addressService;

        public IBannerService BannerService => _bannerService;

        public IBusinessHourService BusinessHourService => _businessHourService;

        public ICategoryService CategoryService => _categoryService;

        public IGalleryService GalleryService => _galleryService;

        public IMessageService MessageService => _messageService;

        public IOurServiceService OurService => _ourServiceService;

        public IProductService ProductService => _productService;

        public IServiceTypeService ServiceTypeService => _serviceTypeService;

        public ISliderService SliderService => _sliderService;

        public ISocialMediaService SocialMediaService => _socialMediaService;

        public ITeamMemberService TeamMemberService => _teamMemberService;

        public ITeamMemberSocialMediaService TeamMemberSocialMediaService => _teamMeberSocialMediaService;

        public ITestimonialService TestimonialService => _testimonialService;

        public IWhyUsDetailService WhyUsDetailService => _whyUsDetailService;

        public IWhyUsService WhyUsService => _whyUsService;
    }
}
