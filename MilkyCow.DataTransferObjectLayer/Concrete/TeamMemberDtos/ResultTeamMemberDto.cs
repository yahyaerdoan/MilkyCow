using MilkyCow.EntityLayer.Concrete;
using System.Text.Json.Serialization;

namespace MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberDtos
{
    public record ResultTeamMemberDto(int TeamMemberId, string FirstName, string LastName, string ImageUrl, string Title, bool Status, int TeamMemberSocialMediaId, [property: JsonIgnore] TeamMemberSocialMedia TeamMemberSocialMedia);
}
