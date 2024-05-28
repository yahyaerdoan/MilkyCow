using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.DataTransferObjectLayer.Concrete.AboutUsDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.AddressDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly IAddressService _addressService;
		private readonly IMapper _mapper;

		public AddressesController(IAddressService addressService, IMapper mapper)
		{
			_addressService = addressService;
			_mapper = mapper;
		}

		[HttpGet("AddressList")]
		public ActionResult AddressList()
		{
			var values = _addressService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultAddressDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetAddressById/{id}")]
		public ActionResult GetAddressById(int id)
		{
			var values = _addressService.GetById(id);
			var resultDtos = _mapper.Map<IEnumerable<ResultAddressDto>>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateAddress")]
		public ActionResult CreateAddress(CreateAddressDto createAddressDto)
		{
			var values = _mapper.Map<Address>(createAddressDto);
			_addressService.Add(values);
			return Ok("Address added.");
		}

		[HttpDelete("DeleteAddress/{id}")]
		public ActionResult DeleteAddress(int id)
		{
			_addressService.Delete(id);
			return Ok("Address deleted.");
		}
		[HttpPut("UpdateAddress")]
		public ActionResult UpdateAddress(UpdateAddressDto updateAddressDto)
		{
			var values = _mapper.Map<Address>(updateAddressDto);
			_addressService.Update(values);
			return Ok("Address updated.");
		}
	}
}
