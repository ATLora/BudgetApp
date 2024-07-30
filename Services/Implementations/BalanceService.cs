using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;
using BudgetApp.Models;
using BudgetApp.Services.Interfaces;

namespace BudgetApp.Services.Implementations
{
    public class BalanceService : IBalanceService
    {
        private readonly ApplicationDbContext _db;

        public BalanceService(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task SetInitialBalance(decimal InitialBalance, string userId)
        {
            var User = _db.Users.Find(userId);
            if (User != null)
            {
                User.AccountsBalance = InitialBalance;

                await _db.SaveChangesAsync();
            }
        }
    }
}
