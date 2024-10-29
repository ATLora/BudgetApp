using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;

namespace BudgetApp.Services.Interfaces
{
    public interface IBudgetItemService
    {
        //Task<IEnumerable<Expense>> GetExpensesAsync(string userId);
        //Task<Expense> GetExpenseByIdAsync(int id, string userId);
        Task AddBudgetItemAsync(BudgetItemDto budgetItemDto, string userId);
        Task UpdateBudgetItemAsync(BudgetItemDto budgetItemDto, string userId);
        Task<List<BudgetItem>> GetAllBudgetItems(string userId);
        List<BudgetItemDto>ConvertBudgetItemToDtoList(List<BudgetItem> budgetItemList);
        Task<bool>CheckIfBudgetItemExist(string userId, int categoryId);
        //Task UpdateExpenseAsync(Expense expense);
        //Task DeleteExpenseAsync(int id, string userId);
    }
}
