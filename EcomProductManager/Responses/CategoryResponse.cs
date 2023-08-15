using EcomProductManager.Models;

namespace EcomProductManager.Responses
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
