namespace MilkyCow.EntityLayer.Concrete
{
    public class TeamMemberSocialMedia
    {
        public int TeamMemberSocialMediaId { get;set; }
        public string AccountName { get; set; }
        public string AccountUrl { get; set; }
        public string Icon { get; set; }
        public bool Status { get; set; }

        public int TeamMemberId { get; set; }
        public virtual TeamMember TeamMember { get; set; }
    }
}