namespace MilkyCow.DataTransferObjectLayer.Concrete.BusinessHourDtos
{
    public record UpdateBusinessHourDto(int BusinessHourId, string Day, string Hour, bool Status);
}
