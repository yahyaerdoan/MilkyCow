using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.SocialMediaDtos
{
    public record CreateSocialMediaDto(string Name, string AccountUrl, string Icon, bool Status);
}
