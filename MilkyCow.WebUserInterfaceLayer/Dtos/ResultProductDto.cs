namespace MilkyCow.WebUserInterfaceLayer.Dtos
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal LastPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}