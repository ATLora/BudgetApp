using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BudgetApp.Models.CoreModels
{
    public class ApplicationUser : IdentityUser
    {
        
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal AccountsBalance { get; set; }
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<Income> Incomes { get; set; } = new List<Income>();
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    }
}
