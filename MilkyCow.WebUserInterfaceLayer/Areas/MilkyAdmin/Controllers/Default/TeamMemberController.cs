using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class TeamMemberController : Controller
    {
        private readonly DynamicConsume<ResultTeamMemberDto> _resultTeamMemberDto;
        private readonly DynamicConsume<CreateTeamMemberDto> _createTeamMemberDto;
        private readonly DynamicConsume<UpdateTeamMemberDto> _updateTeamMemberDto;
        private readonly DynamicConsume<object> _object;

        public TeamMemberController(DynamicConsume<ResultTeamMemberDto> resultTeamMemberDto, DynamicConsume<CreateTeamMemberDto> createTeamMemberDto, DynamicConsume<UpdateTeamMemberDto> updateTeamMemberDto, DynamicConsume<object> oobject)
        {
            _resultTeamMemberDto = resultTeamMemberDto;
            _createTeamMemberDto = createTeamMemberDto;
            _updateTeamMemberDto = updateTeamMemberDto;
            _object = oobject;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _resultTeamMemberDto.GetListAsync("TeamMembers/TeamMemberList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTeamMember()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeamMember(CreateTeamMemberDto createTeamMemberDto)
        {
            var values = await _createTeamMemberDto.PostAsync("TeamMembers/CreateTeamMember", createTeamMemberDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeamMember(int id)
        {
            var values = await _updateTeamMemberDto.GetByIdAsync("TeamMembers/GetTeamMemberById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeamMember(UpdateTeamMemberDto updateTeamMemberDto)
        {
            var values = await _createTeamMemberDto.PutAsync("TeamMembers/UpdateTeamMember", updateTeamMemberDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var values = await _object.DeleteAsync("TeamMembers/DeleteTeamMember", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    } 
}
