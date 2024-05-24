namespace MilkyCow.DataTransferObjectLayer.Concrete.AddressDtos
{
    public record UpdateAddressDto
    {
        public int AddressId { get; init; }
        public string Street { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }
        public string MapLocation { get; init; }
    }}
