using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models.Dtos
{
    public class GoalViewModel
    {
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public required string Icon { get; set; }
        public required string UserId { get; set; }
        public DateTime TargetDate { get; set; }
    }
}
