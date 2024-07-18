﻿using Microsoft.AspNetCore.Mvc;
using BudgetApp.Models.ViewModels;
using BudgetApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BudgetApp.Models.CoreModels;
using BudgetApp.Services.Implementations;
using BudgetApp.Services.Interfaces;

namespace BudgetApp.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIncomeService _incomeService;

        public CreateController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IIncomeService incomeService)
        {
            _db = context;
            _userManager = userManager;
            _incomeService = incomeService;
        }
        [HttpPost]
        public async Task<ActionResult> Create(InitialBudgetViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);
                    var userId = user.Id;
                    //TODO: Create Expenses and goal, also add initialbalance to profile 
                    foreach(var income in model.Incomes) 
                    {
                        await _incomeService.AddIncomeAsync(income, userId);
                    }
                }
                catch (Exception ex)
                {

                }
                
            }
            return View(model);
        }
        public IActionResult Index()
        {
            CreateViewModel initialBudget = new CreateViewModel();
            initialBudget.Categories = _db.Categories.ToList();

            return View(initialBudget);
        }
    }
}
