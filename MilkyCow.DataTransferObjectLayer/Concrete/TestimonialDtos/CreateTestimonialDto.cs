using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.TestimonialDtos
{
    public record CreateTestimonialDto(string FirstName, string LastName, string ImageUrl, string Title, string Description, bool Status);
}
