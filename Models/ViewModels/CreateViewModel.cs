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
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<IncomeViewModel> Incomes { get; set; } = new List<IncomeViewModel>();
        public List<ExpenseViewModel> Expenses { get; set; } = new List<ExpenseViewModel>();
    }
}
