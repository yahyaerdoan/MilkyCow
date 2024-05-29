using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberSocialMediaDtos
{
    public record CreateTeamMemberSocialMediaDto(string AccountName, string AccountUrl, string Icon, bool Status);
}
