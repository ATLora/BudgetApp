using BudgetApp.Models.Dtos;

namespace BudgetApp.Services.Interfaces
{
    public interface IUtilitiesService
    {
        Task<List<BudgetItemDto>> GetIncomeCategoriesAsBudgetItemDtoAsync();
        Task<List<BudgetItemDto>> GetExpenseCategoriesAsBudgetItemAsync();
        List<BudgetItemDto> MergeBudgetItems(List<BudgetItemDto> list1, List<BudgetItemDto> list2);
    }
}
