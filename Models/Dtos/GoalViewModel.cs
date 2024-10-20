using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models.Dtos
{
    public class GoalViewModel
    {
        [Required]
        [Display(Name = "Goal name")]
        public required string Name { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Total to save up $")]
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; } = 0;
        public required string Icon { get; set; } = "fa solid fa-piggy-bank";
        public required string UserId { get; set; }
        [Display(Name = "Target goal date")]
        public DateTime TargetDate { get; set; }
        [Display(Name = "Monthly target savings $")]
        public decimal PeriodicAmount
        {
            get
            {
                if (TargetDate <= DateTime.Now || TargetAmount <= 0)
                {
                    return 0;
                }
                var months = ((TargetDate.Year - DateTime.Now.Year) * 12) + TargetDate.Month - DateTime.Now.Month;
                return months > 0 ? TargetAmount / months : TargetAmount;
            }
        }

    }
}
