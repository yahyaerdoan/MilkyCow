using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class TeamMemberSocialMediaManager : ITeamMemberSocialMediaService
    {
        private readonly ITeamMemberSocialMediaDal _teamMemberSocialMediaDal;

		public TeamMemberSocialMediaManager(ITeamMemberSocialMediaDal teamMemberSocialMediaDal)
		{
			_teamMemberSocialMediaDal = teamMemberSocialMediaDal;
		}

		public void Add(TeamMemberSocialMedia entity)
        {
            _teamMemberSocialMediaDal.Add(entity);
        }

        public void Delete(int id)
        {
            _teamMemberSocialMediaDal.Delete(id);
        }

        public List<TeamMemberSocialMedia> GetAll()
        {
            var values = _teamMemberSocialMediaDal.GetAll();
            return values;
        }

        public TeamMemberSocialMedia GetById(int id)
        {
            var values = _teamMemberSocialMediaDal.GetById(id);
            return values;
        }

        public void Update(TeamMemberSocialMedia entity)
        {
            _teamMemberSocialMediaDal.Update(entity);
        }
    }
}
