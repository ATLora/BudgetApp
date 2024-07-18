﻿using BudgetApp.Models;
using BudgetApp.Models.CoreModels;
using BudgetApp.Models.Dtos;
using BudgetApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Services.Implementations
{
    public class IncomeService : IIncomeService
    {
        private readonly ApplicationDbContext _db;

        public IncomeService(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task AddIncomeAsync(IncomeViewModel incomeDto, string userId)
        {
            var newIncome = new Income
            {
                Name = incomeDto.Name,
                Description = incomeDto.Description,
                ProjectedAmount = incomeDto.ProjectedAmount.Value,
                CategoryId = incomeDto.CategoryId,
                SubCategoryId = incomeDto.SubCategoryId,
                IsRecurrent = incomeDto.IsRecurrent,
                SetRecurrentDay = incomeDto.SetRecurrentDay.Value,
                Date = incomeDto.Date,
                UserId = userId
            };
            _db.Incomes.Add(newIncome);
            await _db.SaveChangesAsync();
        }
    }

}
