using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.OurServiceDtos
{
    public record CreateOurServiceDto(int OurServiceId, string Title, string Description, string ImageUrl, bool Status);
}
