namespace MilkyCow.DataTransferObjectLayer.Concrete.SocialMediaDtos
{
    public record UpdateSocialMediaDto(int SocialMediaId, string Name, string AccountUrl, string Icon, bool Status);
}
