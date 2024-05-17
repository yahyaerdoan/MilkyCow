using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
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
    }
}
