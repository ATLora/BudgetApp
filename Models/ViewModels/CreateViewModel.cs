using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;

namespace BudgetApp.Models.ViewModels
{
    public class CreateViewModel
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public InitialBudgetViewModel? InitialBudget { get; set; }
        public IncomeViewModel? Income { get; set; } = new IncomeViewModel();

    }
    public class InitialBudgetViewModel
    {
        public decimal? InitialBalance { get; set; }
        public GoalViewModel? Goal { get; set; }
        public List<Category> IncomeCategories { get; set; } = new List<Category>();
        public List<Category> ExpenseCategories { get; set; } = new List<Category>();
        public List<BudgetItemDto> Incomes { get; set; } = new List<BudgetItemDto>();
        public List<BudgetItemDto> Expenses { get; set; } = new List<BudgetItemDto>();
        public List<BudgetItemDto> Savings { get; set; } = new List<BudgetItemDto>();

    }
}
