using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;
using BudgetApp.Models;
using BudgetApp.Services.Interfaces;

namespace BudgetApp.Services.Implementations
{
    public class GoalService : IGoalService
    {
        private readonly ApplicationDbContext _db;

        public GoalService(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task AddGoalAsync(GoalViewModel goalDto, string userId)
        {
            var newGoal = new Goal
            {
                Name = goalDto.Name,
                Description = goalDto.Description,
                TargetAmount = goalDto.TargetAmount,
                CurrentAmount = goalDto.CurrentAmount,
                Icon = goalDto.Icon,
                UserId = userId,
                TargetDate = goalDto.TargetDate,
            };
            _db.Goals.Add(newGoal);
            await _db.SaveChangesAsync();
        }
    }
}
