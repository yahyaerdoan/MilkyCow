using AutoMapper;
using MilkyCow.DataTransferObjectLayer.Concrete.AboutUsDtos;
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
		}
	}
}
