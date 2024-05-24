namespace MilkyCow.DataTransferObjectLayer.Concrete.SliderDtos
{
    public record UpdateSliderDto(int SliderId, string? ImageUrl, string? Header, string? Title, string? Description, bool Status);
}
