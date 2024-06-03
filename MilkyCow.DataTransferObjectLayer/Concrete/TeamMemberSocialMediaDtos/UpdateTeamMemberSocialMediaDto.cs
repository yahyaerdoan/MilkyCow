using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberSocialMediaDtos
{
    public record UpdateTeamMemberSocialMediaDto(int TeamMemberSocialMediaId, string AccountName, string AccountUrl, string Icon, bool Status, int TeamMemberId);
}
