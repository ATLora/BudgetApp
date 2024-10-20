using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models.CoreModels
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }
        public Category Category { get; set; }
        public ICollection<BudgetItem> Expenses { get; set; } = new List<BudgetItem>();
        public ICollection<Transaction> Incomes { get; set; } = new List<Transaction>();
    }
}
