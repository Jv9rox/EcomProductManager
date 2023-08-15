using System.ComponentModel.DataAnnotations;

namespace EcomProductManager.Requests
{
    public class CategoryRequests
    {
        [Required(ErrorMessage = "Category name is required.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Display Order is required.")]
        public int DisplayOrder { get; set; }

    }
}
