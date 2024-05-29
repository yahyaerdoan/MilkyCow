using AutoMapper;
using MilkyCow.DataTransferObjectLayer.Concrete.AboutUsDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.AddressDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.BannerDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.BusinessHourDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.CategoryDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.GalleryDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.MessageDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.OurServiceDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.ProductDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.ServiceTypeDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.SliderDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.SocialMediaDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberSocialMediaDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.TestimonialDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.WhyUsDetailDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.WhyUsDtos;
using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.AutoMapper.EntityDtoMappers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<AboutUs, CreateAboutUsDto>().ReverseMap();
			CreateMap<AboutUs, UpdateAboutUsDto>().ReverseMap();
			CreateMap<AboutUs, ResultAboutUsDto>().ReverseMap();

			CreateMap<Address, CreateAddressDto>().ReverseMap();
			CreateMap<Address, UpdateAddressDto>().ReverseMap();
			CreateMap<Address, ResultAddressDto>().ReverseMap();

			CreateMap<Banner, CreateBannerDto>().ReverseMap();
			CreateMap<Banner, UpdateBannerDto>().ReverseMap();
			CreateMap<Banner, ResultBannerDto>().ReverseMap();

			CreateMap<BusinessHour, CreateBusinessHourDto>().ReverseMap();
			CreateMap<BusinessHour, UpdateBusinessHourDto>().ReverseMap();
			CreateMap<BusinessHour, ResultBusinessHourDto>().ReverseMap();

			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();
			CreateMap<Category, ResultCategoryDto>().ReverseMap();

			CreateMap<Gallery, CreateGalleryDto>().ReverseMap();
			CreateMap<Gallery, UpdateGalleryDto>().ReverseMap();
			CreateMap<Gallery, ResultGalleryDto>().ReverseMap();

			CreateMap<Message, CreateMessageDto>().ReverseMap();
			CreateMap<Message, UpdateMessageDto>().ReverseMap();
			CreateMap<Message, ResultMessageDto>().ReverseMap();

			CreateMap<OurService, CreateOurServiceDto>().ReverseMap();
			CreateMap<OurService, UpdateOurServiceDto>().ReverseMap();
			CreateMap<OurService, ResultOurServiceDto>().ReverseMap();

			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
			CreateMap<Product, ResultProductDto>().ReverseMap();

			CreateMap<ServiceType, CreateServiceTypeDto>().ReverseMap();
			CreateMap<ServiceType, UpdateServiceTypeDto>().ReverseMap();
			CreateMap<ServiceType, ResultServiceTypeDto>().ReverseMap();

			CreateMap<Slider, CreateSliderDto>().ReverseMap();
			CreateMap<Slider, UpdateSliderDto>().ReverseMap();
			CreateMap<Slider, ResultSliderDto>().ReverseMap();

			CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();

			CreateMap<TeamMember, CreateTeamMemberDto>().ReverseMap();
			CreateMap<TeamMember, UpdateTeamMemberDto>().ReverseMap();
			CreateMap<TeamMember, ResultTeamMemberDto>().ReverseMap();

			CreateMap<TeamMemberSocialMedia, CreateTeamMemberSocialMediaDto>().ReverseMap();
			CreateMap<TeamMemberSocialMedia, UpdateTeamMemberSocialMediaDto>().ReverseMap();
			CreateMap<TeamMemberSocialMedia, ResultTeamMemberSocialMediaDto>().ReverseMap();

			CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();


			CreateMap<WhyUsDetail, CreateWhyUsDetailDto>().ReverseMap();
			CreateMap<WhyUsDetail, UpdateWhyUsDetailDto>().ReverseMap();
			CreateMap<WhyUsDetail, ResultWhyUsDetailDto>().ReverseMap();

			CreateMap<WhyUs, CreateWhyUsDto>().ReverseMap();
			CreateMap<WhyUs, UpdateWhyUsDto>().ReverseMap();
			CreateMap<WhyUs, ResultWhyUsDto>().ReverseMap();
		}
	}
}
