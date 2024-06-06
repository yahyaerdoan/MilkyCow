using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutTeamMemberViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultTeamMemberDto> _resultTeamMemberDto;

        public LayoutTeamMemberViewComponentPartial(DynamicConsume<ResultTeamMemberDto> resultTeamMemberDto)
        {
            _resultTeamMemberDto = resultTeamMemberDto;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _resultTeamMemberDto.GetListAsync("TeamMembers/TeamMemberList");
            return View(values); 
        }
    }
}
