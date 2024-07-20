using BudgetApp.Models.Dtos;

namespace BudgetApp.Services.Interfaces
{
    public interface IGoalService
    {
        Task AddGoalAsync(GoalViewModel goalDto, string userId);
    }
}
