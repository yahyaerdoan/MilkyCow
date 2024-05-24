using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyCow.DataTransferObjectLayer.Concrete.AddressDtos
{
    public record CreateAddressDto
    {
        public string Street { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }
        public string MapLocation { get; init; }
    }
}
