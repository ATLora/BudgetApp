using BudgetApp.Models.CoreModels;

namespace BudgetApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategory(Category category);
    }
}
