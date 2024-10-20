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
        public ICollection<BudgetItem> Expenses { get; set; } = new List<BudgetItem>();
        public ICollection<Transaction> Incomes { get; set; } = new List<Transaction>();
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    }
}
