using EcomProductManager.Models;

namespace EcomProductManager.Responses
{
    public class ProductResponse
    {
        public class GetProductDetailsResponse
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public DateTime CreatedDate { get; set; } = DateTime.Now;
            public int CategoryId { get; set; }
            public Category Category { get; set; }
        }

    }
}
