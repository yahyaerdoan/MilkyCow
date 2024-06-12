using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberSocialMediaDtos
{
    public record ResultTeamMemberSocialMediaDto(int TeamMemberSocialMediaId, string AccountName, string AccountUrl, string Icon, bool Status, int TeamMemberId, TeamMember TeamMember);
}
