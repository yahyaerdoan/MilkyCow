using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberDtos;
using MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberSocialMediaDtos;
using MilkyCow.EntityLayer.Concrete;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class TeamMemberSocialMediaController : Controller
    {
        private readonly DynamicConsume<ResultTeamMemberFullNameDto> _fullName;
        private readonly DynamicConsume<ResultTeamMemberSocialMediaDto> _resultTeamMemberSocialMediaDto;
        private readonly DynamicConsume<CreateTeamMemberSocialMediaDto> _createTeamMemberSocialMediaDto;
        private readonly DynamicConsume<UpdateTeamMemberSocialMediaDto> _updateTeamMemberSocialMediaDto;
        private readonly DynamicConsume<object> _object;

        public TeamMemberSocialMediaController(DynamicConsume<ResultTeamMemberSocialMediaDto> resultTeamMemberSocialMediaDto, DynamicConsume<CreateTeamMemberSocialMediaDto> createTeamMemberSocialMediaDto, DynamicConsume<UpdateTeamMemberSocialMediaDto> updateTeamMemberSocialMediaDto, DynamicConsume<object> objects, DynamicConsume<ResultTeamMemberFullNameDto> fullName)
        {
            _resultTeamMemberSocialMediaDto = resultTeamMemberSocialMediaDto;
            _createTeamMemberSocialMediaDto = createTeamMemberSocialMediaDto;
            _updateTeamMemberSocialMediaDto = updateTeamMemberSocialMediaDto;
            _object = objects;
            _fullName = fullName;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _resultTeamMemberSocialMediaDto.GetListAsync("TeamMemberSocialMedias/TeamMemberSocialMediaListWithTeamMember");
            return View(values);
        }
        public async Task<IActionResult> TeamMemberSocialMediaList(int id)
        {
            var values = await _resultTeamMemberSocialMediaDto.GetListByIdAsync("TeamMemberSocialMedias/TeamMemberSocialMediaListByTeamMember", id);
            ViewBag.TeamMemberId = id;
            if (values != null)
            {
                return View(values);
            }
            return View();
        }
        #region Set Team Member Full Name And Id
        private async Task SetTeamMemberFullNameAndIdAsync(int id)
        {
            var fullName = await _fullName.GetByIdAsync("TeamMembers/TeamMemberFullName", id);
            if (fullName != null && !string.IsNullOrEmpty(fullName.FullName))
            {
                ViewBag.TeamMemberFullName = fullName.FullName;
            }
            else
            {
                ViewBag.TeamMemberFullName = "Unknown Team Member";
            }
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> CreateTeamMemberSocialMedia(int id)
        {
            ViewBag.TeamMemberId = id;
            await SetTeamMemberFullNameAndIdAsync(id);
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

        #region  Get Team Member Full Name
        private async Task<string> GetTeamMemberFullNameAsync(int id)
        {
            var resultFullName = await _resultTeamMemberSocialMediaDto.GetByIdAsync("TeamMemberSocialMedias/TeamMemberSocialMediaByTeamMemberId", id);
            if (resultFullName != null && resultFullName.TeamMember != null)
            {
                return $"{resultFullName.TeamMember.FirstName} {resultFullName.TeamMember.LastName}";
            }
            return "Unknown Team Member";
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> UpdateTeamMemberSocialMedia(int id)
        {
            ViewBag.TeamMemberFullName = await GetTeamMemberFullNameAsync(id);
            var values = await _updateTeamMemberSocialMediaDto.GetByIdAsync("TeamMemberSocialMedias/GetTeamMemberSocialMediaById", id);          
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
