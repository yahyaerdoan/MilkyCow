using MilkyCow.DataAccessLayer.Abstract.IGenericRepository;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.DataAccessLayer.Abstract.IAbstractDal
{
    public interface ITeamMemberDal : IGenericRepository<TeamMember>
    {
        string GetTeamMemberFullName(int id);
    }
}
