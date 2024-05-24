using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberSocialMediaDtos
{
    public record CreateTeamMemberSocialMediaDto(string AccountName, string AccountUrl, string Icon, bool Status, List<TeamMember> TeamMembers);
}
