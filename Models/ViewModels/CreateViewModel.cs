using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;

namespace BudgetApp.Models.ViewModels
{
    public class CreateViewModel
    {
        public List<Category> Categories { get; set; } = new List<Category>();

    }
    public class InitialBudgetViewModel
    {
        public decimal InitialBalance { get; set; }
        public string Objective { get; set; }
        public List<IncomeViewModel> Incomes { get; set; } = new List<IncomeViewModel>();
        public List<ExpenseViewModel> Expenses { get; set; } = new List<ExpenseViewModel>();
    }
}
