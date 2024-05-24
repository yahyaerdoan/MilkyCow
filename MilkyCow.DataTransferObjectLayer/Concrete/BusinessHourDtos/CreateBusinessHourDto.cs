using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.BusinessHourDtos
{
    public record CreateBusinessHourDto(string Day, string Hour, bool Status);
}
