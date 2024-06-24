using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models.CoreModels
{
    public class Saving
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal LastMonthTotal { get; set; }

        [Required]
        public DateTime Month { get; set; } 

    
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
