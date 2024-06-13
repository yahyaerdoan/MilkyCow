using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class TeamMemberManager : ITeamMemberService
    {
        private readonly ITeamMemberDal _memberDal;

		public TeamMemberManager(ITeamMemberDal memberDal)
		{
			_memberDal = memberDal;
		}

		public void Add(TeamMember entity)
        {
            _memberDal.Add(entity);
        }

        public void Delete(int id)
        {
            _memberDal.Delete(id);
        }

        public List<TeamMember> GetAll()
        {
            var vaues = _memberDal.GetAll();    
            return vaues;
        }

        public TeamMember GetById(int id)
        {
            var values = _memberDal.GetById(id);
            return values;
        }

        public string GetTeamMemberFullName(int id)
        {
            var values = _memberDal.GetTeamMemberFullName(id);
            return values;
        }

        public void Update(TeamMember entity)
        {
            _memberDal.Update(entity);
        }
    }
}
