using MilkyCow.EntityLayer.Concrete;
using System.Text.Json.Serialization;

namespace MilkyCow.DataTransferObjectLayer.Concrete.ProductDtos
{
    public record ResultProductDto(
        int ProductId, 
        string? Name, 
        decimal LastPrice, 
        decimal NewPrice, 
        string? Image, 
        bool Status, 
        int? CategoryId, 
        //[property: JsonIgnore]
        Category Category);
}
