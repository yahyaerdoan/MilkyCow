using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.GalleryDtos
{
    public record CreateGalleryDto(string ImageUrl, bool Status);
}
