using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstact.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeamMembersController : ControllerBase
	{
		private readonly IServiceManager _ServiceManger;
		private readonly IMapper _mapper;

		public TeamMembersController(IMapper mapper, IServiceManager ServiceManger)
		{
			_mapper = mapper;
			_ServiceManger = ServiceManger;
		}

		[HttpGet("TeamMemberList")]
		public ActionResult TeamMemberList()
		{
			var values = _ServiceManger.TeamMemberService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultTeamMemberDto>>(values);
			return Ok(resultDtos);
		}

		[HttpGet("GetTeamMemberById/{id}")]
		public ActionResult GetTeamMemberById(int id)
		{
			var values = _ServiceManger.TeamMemberService.GetById(id);
			var resultDtos = _mapper.Map<TeamMember,ResultTeamMemberDto>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateTeamMember")]
		public ActionResult CreateTeamMember(CreateTeamMemberDto createTeamMemberDto)
		{
			var values = _mapper.Map<TeamMember>(createTeamMemberDto);
			_ServiceManger.TeamMemberService.Add(values);
			return Ok("TeamMember added.");
		}

		[HttpDelete("DeleteTeamMember/{id}")]
		public ActionResult DeleteTeamMember(int id)
		{
			_ServiceManger.TeamMemberService.Delete(id);
			return Ok("TeamMember deleted.");
		}
		[HttpPut("UpdateTeamMember")]
		public ActionResult UpdateTeamMember(UpdateTeamMemberDto updateTeamMemberDto)
		{
			var values = _mapper.Map<TeamMember>(updateTeamMemberDto);
			_ServiceManger.TeamMemberService.Update(values);
			return Ok("TeamMember updated.");
		}
	}
}
