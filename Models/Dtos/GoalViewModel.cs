using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models.Dtos
{
    public class GoalViewModel
    {
        [Required]
        [Display(Name = "Goal Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Periodic Amount")]
        [DataType(DataType.Currency)]
        public decimal PeriodicAmount { get; set; }

        [Display(Name = "Target Amount")]
        [DataType(DataType.Currency)]
        public decimal TargetAmount { get; set; }

        [Display(Name = "Current Amount")]
        [DataType(DataType.Currency)]
        public decimal CurrentAmount { get; set; }

        [Display(Name = "Icon URL")]
        public string? Icon { get; set; }

        public string UserId { get; set; }
    }
}
