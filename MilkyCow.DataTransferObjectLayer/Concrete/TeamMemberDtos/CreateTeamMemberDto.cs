using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberDtos
{
    public record CreateTeamMemberDto(string FirstName, string LastName, string ImageUrl, string Title, bool Status, int TeamMemberSocialMediaId);
}
