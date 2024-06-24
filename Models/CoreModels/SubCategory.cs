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
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<Income> Incomes { get; set; } = new List<Income>();
    }
}
