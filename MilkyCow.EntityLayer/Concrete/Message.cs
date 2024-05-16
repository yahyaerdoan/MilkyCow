namespace MilkyCow.EntityLayer.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public string FullName { get; set; }   
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendingDate { get; set; }
        public bool IsRead { get; set; }
    }
}