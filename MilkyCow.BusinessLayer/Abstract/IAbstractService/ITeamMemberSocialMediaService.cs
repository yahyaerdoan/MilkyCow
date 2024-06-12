using MilkyCow.BusinessLayer.Abstract.IGenericService;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Abstract.IAbstractService
{
    public interface ITeamMemberSocialMediaService : IGenericService<TeamMemberSocialMedia>
    {
        List<TeamMemberSocialMedia> GetTeamMemberSocialMediaListByTeamMemberId(int id);
        TeamMemberSocialMedia GetTeamMemberSocialMediaByTeamMemberId(int id);

        List<TeamMemberSocialMedia> GetTeamMemberSocialMediaListWithTeamMember();
    }
}