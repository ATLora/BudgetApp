using BudgetApp.Models;
using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;
using BudgetApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Services.Implementations
{
    public class IncomeService : ITransactionService
    {
        private readonly ApplicationDbContext _db;

        public IncomeService(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task AddIncomeAsync(IncomeViewModel incomeDto, string userId)
        {
            var newIncome = new Transaction
            {
                Name = incomeDto.Name,
                Description = incomeDto.Description,
                ProjectedAmount = incomeDto.ProjectedAmount != null ? incomeDto.ProjectedAmount.Value : null,
                RealAmount = incomeDto.RealAmount != null ? incomeDto.RealAmount.Value : null,
                CategoryId = incomeDto.CategoryId,
                SubCategoryId = incomeDto.SubCategoryId,
                IsRecurrent = incomeDto.IsRecurrent,
                SetRecurrentDay = incomeDto.SetRecurrentDay != null ? incomeDto.SetRecurrentDay.Value : null,
                Date = incomeDto.Date,
                UserId = userId
            };
            _db.Transactions.Add(newIncome);
            await _db.SaveChangesAsync();
        }
    }

}
