namespace MilkyCow.DataTransferObjectLayer.Concrete.AboutUsDtos
{
    public record UpdateAboutUsDto
    {
        public int AboutUsId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
    }
}
