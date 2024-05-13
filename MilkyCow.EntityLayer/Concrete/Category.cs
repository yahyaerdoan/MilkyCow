using System.Text.Json.Serialization;

namespace MilkyCow.EntityLayer.Concrete
{
    public class Category
	{
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public virtual List<Product> Products { get; set; }
    }
}