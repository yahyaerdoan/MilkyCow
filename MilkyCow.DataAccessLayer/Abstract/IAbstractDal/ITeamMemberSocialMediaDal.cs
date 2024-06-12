using MilkyCow.DataAccessLayer.Abstract.IGenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Abstract.IAbstractDal
{
    public interface ITeamMemberSocialMediaDal : IGenericRepository<TeamMemberSocialMedia>
    {
        List<TeamMemberSocialMedia> GetTeamMemberSocialMediaListByTeamMemberId(int id);
    }  
}
