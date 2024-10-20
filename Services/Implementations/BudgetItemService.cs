using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;
using BudgetApp.Models;
using BudgetApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Services.Implementations
{
    public class BudgetItemService : IBudgetItemService
    {
        private readonly ApplicationDbContext _db;

        public BudgetItemService(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task AddBudgetItemAsync(BudgetItemDto budgetItemDto, string userId)
        {
            var newExpense = new BudgetItem
            {
                Name = budgetItemDto.Name,
                Description = budgetItemDto.Description,
                ProjectedAmount = budgetItemDto.ProjectedAmount != null ? budgetItemDto.ProjectedAmount.Value : null,
                RealAmount = budgetItemDto.RealAmount != null ? budgetItemDto.RealAmount.Value : null,
                CategoryId = budgetItemDto.CategoryId,
                SubCategoryId = budgetItemDto.SubCategoryId,
                IsRecurrent = budgetItemDto.IsRecurrent,
                SetRecurrentDay = budgetItemDto.SetRecurrentDay != null ? budgetItemDto.SetRecurrentDay.Value : null,
                Date = budgetItemDto.Date,
                TransactionType = budgetItemDto.TransactionType,
                UserId = userId
            };
            _db.BudgetItems.Add(newExpense);
            await _db.SaveChangesAsync();
        }
        public async Task<List<BudgetItem>> GetAllBudgetItems(string userId)
        {
            var existingBudgetItem = await _db.BudgetItems
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return existingBudgetItem;
        }
        public  List<BudgetItemDto> ConvertBudgetItemToDtoList(List<BudgetItem> budgetItemList)
        {
            return budgetItemList.Select(item => new BudgetItemDto
            {
                Name = item.Name,
                Description = item.Description,
                ProjectedAmount = item.ProjectedAmount,
                RealAmount = item.RealAmount,
                CategoryId = item.CategoryId,
                SubCategoryId = item.SubCategoryId,
                IsRecurrent = item.IsRecurrent,
                TransactionType = item.TransactionType,
                SetRecurrentDay = item.SetRecurrentDay,
                Date = item.Date
            }).ToList();
        }
    }
}
