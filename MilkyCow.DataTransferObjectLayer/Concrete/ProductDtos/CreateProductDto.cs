using MilkyCow.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.ProductDtos
{
    public record CreateProductDto(
            string? Name,
            decimal LastPrice,
            decimal NewPrice,
            string? Image,
            bool Status, int?
            CategoryId,
            [property: JsonIgnore] 
            Category Category
    );
}
