using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MilkyCow.EntityLayer.Concrete
{

    public class Product
	{
		public int ProductId { get; set; }
		public string? Name { get; set; }
		public decimal LastPrice { get; set; }
		public decimal NewPrice { get; set; }
        public string? Image { get; set; }
        public bool Status { get; set; }
        public int? CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}