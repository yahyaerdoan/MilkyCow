﻿namespace MilkyCow.EntityLayer.Concrete
{
    public class TeamMember
    {
        public int TeamMemberId { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public virtual List<TeamMemberSocialMedia> TeamMemberSocialMedias { get; set; }
    }
}