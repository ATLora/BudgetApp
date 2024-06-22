using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models.CoreModels
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Icon { get; set; }
    }
}
