namespace MilkyCow.DataTransferObjectLayer.Concrete.ServiceTypeDtos
{
    public record UpdateServiceTypeDto(int ServiceTypeId, string Title, string Description, string Icon, bool Status);
}
