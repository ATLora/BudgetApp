using BudgetApp.Models.CoreModels;

namespace BudgetApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategory(Category category);
        Task<List<Category>> GetAllCategories();
        Task<List<Category>> GetAllCategories(string categoryType);
        Task<string> GetCategoryName(int categoryId);
    }
}
