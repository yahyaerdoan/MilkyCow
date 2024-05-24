namespace MilkyCow.DataTransferObjectLayer.Concrete.MessageDtos
{
    public record ResultMessageDto(int MessageId, string FullName, string Email, string Subject, string Content, DateTime SendingDate, bool IsRead);
}
