using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.GenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Concrete.EntityFramework
{
    public class EfTeamMemberDal : EfGenericRepository<TeamMember, MilkyCowDbContext>, ITeamMemberDal
    {
        public EfTeamMemberDal(MilkyCowDbContext context) : base(context)
        {
        }

        public string GetTeamMemberFullName(int id)
        {
            var values = _context.TeamMembers.Find(id);
            return String.Concat(values.FirstName + " " + values.LastName);          
        }
    }
}
