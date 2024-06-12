using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberSocialMediaDtos;
using MilkyCow.EntityLayer.Concrete;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class TeamMemberSocialMediaController : Controller
    {
        private readonly DynamicConsume<ResultTeamMemberSocialMediaDto> _resultTeamMemberSocialMediaDto;
        private readonly DynamicConsume<CreateTeamMemberSocialMediaDto> _createTeamMemberSocialMediaDto;
        private readonly DynamicConsume<UpdateTeamMemberSocialMediaDto> _updateTeamMemberSocialMediaDto;
        private readonly DynamicConsume<object> _object;

        public TeamMemberSocialMediaController(DynamicConsume<ResultTeamMemberSocialMediaDto> resultTeamMemberSocialMediaDto, DynamicConsume<CreateTeamMemberSocialMediaDto> createTeamMemberSocialMediaDto, DynamicConsume<UpdateTeamMemberSocialMediaDto> updateTeamMemberSocialMediaDto, DynamicConsume<object> objects)
        {
            _resultTeamMemberSocialMediaDto = resultTeamMemberSocialMediaDto;
            _createTeamMemberSocialMediaDto = createTeamMemberSocialMediaDto;
            _updateTeamMemberSocialMediaDto = updateTeamMemberSocialMediaDto;
            _object = objects;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _resultTeamMemberSocialMediaDto.GetListAsync("TeamMemberSocialMedias/TeamMemberSocialMediaListWithTeamMember");
            return View(values);
        }
        public async Task<IActionResult> TeamMemberSocialMediaList(int id)
        {
            var values = await _resultTeamMemberSocialMediaDto.GetListByIdAsync("TeamMemberSocialMedias/TeamMemberSocialMediaListByTeamMember", id);
            if (values != null)
            {
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateTeamMemberSocialMedia(int id)
        {
            var resultFullName = await _resultTeamMemberSocialMediaDto.GetByIdAsync("TeamMemberSocialMedias/TeamMemberSocialMediaByTeamMemberId", id);
            ViewBag.TeamMemberFullName = $"{resultFullName.TeamMember.FirstName} {resultFullName.TeamMember.LastName}";
            ViewBag.TeamMemberId = resultFullName.TeamMemberId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateTeamMemberSocialMedia(CreateTeamMemberSocialMediaDto createTeamMemberSocialMediaDto)
        {
            var values = await _createTeamMemberSocialMediaDto.PostAsync("TeamMemberSocialMedias/CreateTeamMemberSocialMedia", createTeamMemberSocialMediaDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeamMemberSocialMedia(int id)
        {           
         
            var values = await _updateTeamMemberSocialMediaDto.GetByIdAsync("TeamMemberSocialMedias/GetTeamMemberSocialMediaById", id);
            var resultFullName = await _resultTeamMemberSocialMediaDto.GetByIdAsync("TeamMemberSocialMedias/TeamMemberSocialMediaByTeamMemberId", id);
            ViewBag.TeamMemberFullName = $"{resultFullName.TeamMember.FirstName} {resultFullName.TeamMember.LastName}";
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeamMemberSocialMedia(UpdateTeamMemberSocialMediaDto updateTeamMemberSocialMediaDto)
        {
            var values = await _updateTeamMemberSocialMediaDto.PutAsync("TeamMemberSocialMedias/UpdateTeamMemberSocialMedia", updateTeamMemberSocialMediaDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteTeamMemberSocialMedia(int id)
        {
            var values = await _object.DeleteAsync("TeamMemberSocialMedias/DeleteTeamMemberSocialMedia", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    } 
}
