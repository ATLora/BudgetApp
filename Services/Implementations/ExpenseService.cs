using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;
using BudgetApp.Models;
using BudgetApp.Services.Interfaces;

namespace BudgetApp.Services.Implementations
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext _db;

        public ExpenseService(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task AddExpenseAsync(ExpenseViewModel expenseDto, string userId)
        {
            var newExpense = new Expense
            {
                Name = expenseDto.Name,
                Description = expenseDto.Description,
                ProjectedAmount = expenseDto.ProjectedAmount != null ? expenseDto.ProjectedAmount.Value : null,
                RealAmount = expenseDto.RealAmount != null ? expenseDto.RealAmount.Value : null,
                CategoryId = expenseDto.CategoryId,
                SubCategoryId = expenseDto.SubCategoryId,
                IsRecurrent = expenseDto.IsRecurrent,
                SetRecurrentDay = expenseDto.SetRecurrentDay != null ? expenseDto.SetRecurrentDay.Value : null,
                Date = expenseDto.Date,
                UserId = userId
            };
            _db.Expenses.Add(newExpense);
            await _db.SaveChangesAsync();
        }
    }
}
