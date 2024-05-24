using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.SliderDtos
{
    public record CreateSliderDto(string? ImageUrl, string? Header, string? Title, string? Description, bool Status);
}
