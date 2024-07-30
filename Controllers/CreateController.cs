using Microsoft.AspNetCore.Mvc;
using BudgetApp.Models.ViewModels;
using BudgetApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BudgetApp.Models.CoreModels;
using BudgetApp.Services.Implementations;
using BudgetApp.Services.Interfaces;
using BudgetApp.Models.Dtos;

namespace BudgetApp.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIncomeService _incomeService;
        private readonly IExpenseService _expenseService;
        private readonly IGoalService _goalService;
        private readonly IBalanceService _balanceService;

        public CreateController(ApplicationDbContext context, 
                                UserManager<ApplicationUser> userManager,
                                IIncomeService incomeService,
                                IExpenseService expenseService,
                                IGoalService goalService,
                                IBalanceService balanceService
                                )
        {
            _db = context;
            _userManager = userManager;
            _incomeService = incomeService;
            _expenseService = expenseService;
            _goalService = goalService;
            _balanceService = balanceService;
        }
        [HttpPost]
        public async Task<ActionResult> Create(InitialBudgetViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null) 
                    {
                        var userId = user.Id;

                        foreach (var income in model.Incomes)
                        {
                            if (income.ProjectedAmount != null)
                            {
                                await _incomeService.AddIncomeAsync(income, userId);
                            }
                        }

                        foreach (var expense in model.Expenses)
                        {
                            if (expense.ProjectedAmount != null)
                            {
                                await _expenseService.AddExpenseAsync(expense, userId);
                            }
                        }

                        if (model.InitialBalance != null)
                        {
                            await _balanceService.SetInitialBalance(model.InitialBalance.Value, userId);
                        }
                    }   
                }
                catch (Exception ex)
                {
                    // Manejar la excepción de manera adecuada, por ejemplo, registrándola y mostrando un mensaje de error al usuario.
                    ModelState.AddModelError("", "An error occurred while creating the budget. Please try again.");
                }
            }

            if (ModelState.IsValid)
            {
                // Redirigir a la acción Index si todo salió bien
                return RedirectToAction("Index");
            }

            // Si no es válido, volver a preparar el modelo y devolver la vista Create
            var categories = _db.Categories.ToList();
            var incomes = categories.Where(c => c.Type == "Income").Select(c => new IncomeViewModel { CategoryId = c.Id }).ToList();
            var expenses = categories.Where(c => c.Type == "Expense").Select(c => new ExpenseViewModel { CategoryId = c.Id }).ToList();

            var initialBudget = new InitialBudgetViewModel
            {
                Categories = categories,
                Incomes = incomes,
                Expenses = expenses
            };

            return View("Index",initialBudget);
        }

        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            var incomes = categories.Where(c => c.Type == "Income").Select(c => new IncomeViewModel { Name = "!PBIncome" + c.Name, CategoryId = c.Id }).ToList();
            var expenses = categories.Where(c => c.Type == "Expense").Select(c => new ExpenseViewModel { Name = "!PBIncome" + c.Name, CategoryId = c.Id }).ToList();

            var model = new InitialBudgetViewModel
            {
                Categories = categories,
                Incomes = incomes,
                Expenses = expenses
            };

            return View(model);
        }

    }
}
