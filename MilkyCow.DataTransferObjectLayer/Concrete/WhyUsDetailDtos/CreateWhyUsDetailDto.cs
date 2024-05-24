using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.WhyUsDetailDtos
{
    public record CreateWhyUsDetailDto(string Title, string Description, bool Status);
}
