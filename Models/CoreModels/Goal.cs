using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models.CoreModels
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal PeriodicAmount { get; set; }
        [NotMapped]
        public decimal TargetAmount { get; set; }
        [NotMapped]
        public decimal CurrentAmount { get; set; }
        public string? Icon { get; set; }
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
