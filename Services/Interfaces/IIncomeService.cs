using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;
using BudgetApp.Models.ViewModels;


namespace BudgetApp.Services.Interfaces
{
    public interface IIncomeService
    {
        //Task<IEnumerable<Income>> GetIncomesAsync(string userId);
        //Task<Income> GetIncomeByIdAsync(int id, string userId);
        Task AddIncomeAsync(IncomeViewModel incomeDto, string userId);
        //Task UpdateIncomeAsync(Income income);
        //Task DeleteIncomeAsync(int id, string userId);
    }
}
