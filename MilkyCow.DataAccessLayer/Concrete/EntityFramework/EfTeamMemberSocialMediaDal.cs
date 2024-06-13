using Microsoft.EntityFrameworkCore;
using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfTeamMemberSocialMediaDal : EfGenericRepository<TeamMemberSocialMedia, MilkyCowDbContext>, ITeamMemberSocialMediaDal
    {
        public EfTeamMemberSocialMediaDal(MilkyCowDbContext context) : base(context)
        {
        }

        public List<TeamMemberSocialMedia> GetTeamMemberSocialMediaListByTeamMemberId(int id)
        {
            var values = _context.TeamMemberSocialMedias.Include(y=> y.TeamMember). Where(x=> x.TeamMemberId == id).ToList();
            return values;
        }

        public TeamMemberSocialMedia GetTeamMemberSocialMediaByTeamMemberId(int id)
        {
            var values = _context.TeamMemberSocialMedias.Include(y => y.TeamMember).FirstOrDefault(x => x.TeamMemberSocialMediaId == id);
            return values;
        }

        public List<TeamMemberSocialMedia> GetTeamMemberSocialMediaListWithTeamMember()
        {
            var values = _context.TeamMemberSocialMedias.Include(y => y.TeamMember).ToList();
            return values;
        }
    }
}
