using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.AboutUsDtos
{
    public record CreateAboutUsDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
    }
}
