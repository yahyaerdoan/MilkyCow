using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.ServiceTypeDtos
{
    public record CreateServiceTypeDto(string Title, string Description, string Icon, bool Status);
}
