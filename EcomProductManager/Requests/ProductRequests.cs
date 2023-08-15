using System.ComponentModel.DataAnnotations;

namespace EcomProductManager.Requests
{
    public class ProductRequests
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }
    }
}
