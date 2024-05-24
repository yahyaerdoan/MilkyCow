using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.MessageDtos
{
    public record CreateMessageDto(string FullName, string Email, string Subject, string Content, DateTime SendingDate, bool IsRead);
}
