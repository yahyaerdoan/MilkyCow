namespace MilkyCow.DataTransferObjectLayer.Concrete.OurServiceDtos
{
    public record UpdateOurServiceDto(int OurServiceId, string Title, string Description, string ImageUrl, bool Status);
}
