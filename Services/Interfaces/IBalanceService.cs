using BudgetApp.Models.Dtos;

namespace BudgetApp.Services.Interfaces
{
    public interface IBalanceService
    {
        Task SetInitialBalance(decimal InitialBalance, string userId);
    }
}
