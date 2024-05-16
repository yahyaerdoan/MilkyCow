namespace MilkyCow.EntityLayer.Concrete
{
    public class Address
    {
        public int AddressId { get; set; } 
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MapLocation { get; set; }
    }
}