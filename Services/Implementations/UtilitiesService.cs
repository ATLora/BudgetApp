using BudgetApp.Models;
using BudgetApp.Models.Dtos;
using BudgetApp.Models.Helpers;
using BudgetApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Services.Implementations
{
    public class UtilitiesService : IUtilitiesService
    {
        private readonly ApplicationDbContext _db;

        public UtilitiesService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<List<BudgetItemDto>> GetIncomeCategoriesAsBudgetItemDtoAsync()
        {
            var incomes = await _db.Categories
                .Where(c => c.Type == "Income")
                .Select(c => new BudgetItemDto
                {
                    Name = c.Name,
                    CategoryId = c.Id,
                    TransactionType = MasterData.TransactionTypes.Income
                })
                .ToListAsync();

            return incomes;
        }
        public async Task<List<BudgetItemDto>> GetExpenseCategoriesAsBudgetItemAsync()
        {
            var expense = await _db.Categories
                .Where(c => c.Type == "Expense")
                .Select(c => new BudgetItemDto
                {
                    Name = c.Name,
                    CategoryId = c.Id,
                    TransactionType = MasterData.TransactionTypes.Expense
                })
                .ToListAsync();

            return expense;
        }
        public List<BudgetItemDto> MergeBudgetItems(List<BudgetItemDto> list1, List<BudgetItemDto> list2)
        {
            var mergedList = list1.Concat(list2)
                .GroupBy(item => item.CategoryId)
                .Select(group =>
                {
                    if (group.Count() == 1)
                        return group.First();
                    var itemWithProjectedAmount = group.FirstOrDefault(i => i.ProjectedAmount.HasValue);
                    return itemWithProjectedAmount ?? group.First(); 
                })
                .ToList();

            return mergedList;
        }
    }
}
