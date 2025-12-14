using OrderProject.EntityLayer.Concrete;

namespace OrderProject.WebUI.Dtos.ProductDto
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
