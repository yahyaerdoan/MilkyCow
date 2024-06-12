using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyCow.BusinessLayer.Abstract.IServiceManager;
using MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberSocialMediaDtos;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.RestfulApiLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeamMemberSocialMediasController : ControllerBase
	{
		private readonly IServiceManager _serviceManger;
		private readonly IMapper _mapper;

		public TeamMemberSocialMediasController(IMapper mapper, IServiceManager serviceManger)
		{
			_mapper = mapper;
			_serviceManger = serviceManger;
		}

		[HttpGet("TeamMemberSocialMediaList")]
		public ActionResult TeamMemberSocialMediaList()
		{
			var values = _serviceManger.TeamMemberSocialMediaService.GetAll();
			var resultDtos = _mapper.Map<IEnumerable<ResultTeamMemberSocialMediaDto>>(values);
			return Ok(resultDtos);
		}

        [HttpGet("TeamMemberSocialMediaListByTeamMember/{id}")]
        public ActionResult GetTeamMemberSocialMediaListByTeamMemberId(int id)
        {
            var values = _serviceManger.TeamMemberSocialMediaService.GetTeamMemberSocialMediaListByTeamMemberId(id);
            var resultDtos = _mapper.Map<IEnumerable<ResultTeamMemberSocialMediaDto>>(values);
            return Ok(resultDtos);
        }

        [HttpGet("GetTeamMemberSocialMediaById/{id}")]
		public ActionResult GetTeamMemberSocialMediaById(int id)
		{
			var values = _serviceManger.TeamMemberSocialMediaService.GetById(id);
			var resultDtos = _mapper.Map<TeamMemberSocialMedia,ResultTeamMemberSocialMediaDto>(values);
			return Ok(resultDtos);
		}

		[HttpPost("CreateTeamMemberSocialMedia")]
		public ActionResult CreateTeamMemberSocialMedia(CreateTeamMemberSocialMediaDto createTeamMemberSocialMediaDto)
		{
			var values = _mapper.Map<TeamMemberSocialMedia>(createTeamMemberSocialMediaDto);
			_serviceManger.TeamMemberSocialMediaService.Add(values);
			return Ok("TeamMemberSocialMedia added.");
		}

		[HttpDelete("DeleteTeamMemberSocialMedia/{id}")]
		public ActionResult DeleteTeamMemberSocialMedia(int id)
		{
			_serviceManger.TeamMemberSocialMediaService.Delete(id);
			return Ok("TeamMemberSocialMedia deleted.");
		}
		[HttpPut("UpdateTeamMemberSocialMedia")]
		public ActionResult UpdateTeamMemberSocialMedia(UpdateTeamMemberSocialMediaDto updateTeamMemberSocialMediaDto)
		{
			var values = _mapper.Map<TeamMemberSocialMedia>(updateTeamMemberSocialMediaDto);
			_serviceManger.TeamMemberSocialMediaService.Update(values);
			return Ok("TeamMemberSocialMedia updated.");
		}
	}
}
