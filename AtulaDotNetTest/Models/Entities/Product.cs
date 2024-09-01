using System.ComponentModel.DataAnnotations;

namespace AtulaDotNetTest.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Sku { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        // Navigation property
        public List<Category> Categories { get; set; }

        public List<int> SelectedCategoryIds { get; set; } = new List<int>();
    }
}
