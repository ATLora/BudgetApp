using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models.Dtos
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
