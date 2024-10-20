using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models.CoreModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Icon { get; set; }
        public ICollection<BudgetItem> Expenses { get; set; } = new List<BudgetItem>();
        public ICollection<Transaction> Incomes { get; set; } = new List<Transaction>();

    }
}
