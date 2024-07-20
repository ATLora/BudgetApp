using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;

namespace BudgetApp.Services.Interfaces
{
    public interface IExpenseService
    {
        //Task<IEnumerable<Expense>> GetExpensesAsync(string userId);
        //Task<Expense> GetExpenseByIdAsync(int id, string userId);
        Task AddExpenseAsync(ExpenseViewModel expenseDto, string userId);
        //Task UpdateExpenseAsync(Expense expense);
        //Task DeleteExpenseAsync(int id, string userId);
    }
}
