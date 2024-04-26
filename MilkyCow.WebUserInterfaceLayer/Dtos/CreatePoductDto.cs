namespace MilkyCow.WebUserInterfaceLayer.Dtos
{
    public class CreatePoductDto
    {
        public string? Name { get; set; }
        public decimal LastPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string? Image { get; set; }
        public bool Status { get; set; }
    }
}
