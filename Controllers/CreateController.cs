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
using BudgetApp.Models.Helpers;

namespace BudgetApp.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITransactionService _incomeService;
        private readonly IBudgetItemService _budgetItemService;
        private readonly IGoalService _goalService;
        private readonly IBalanceService _balanceService;
        private readonly IUtilitiesService _utilitiesService;

        public CreateController(ApplicationDbContext context, 
                                UserManager<ApplicationUser> userManager,
                                ITransactionService incomeService,
                                IBudgetItemService expenseService,
                                IGoalService goalService,
                                IBalanceService balanceService,
                                IUtilitiesService utilitiesService)
        {
            _db = context;
            _userManager = userManager;
            _incomeService = incomeService;
            _budgetItemService = expenseService;
            _goalService = goalService;
            _balanceService = balanceService;
            _utilitiesService = utilitiesService;
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
                                await _budgetItemService.AddBudgetItemAsync(income, userId);
                            }
                        }

                        foreach (var expense in model.Expenses)
                        {
                            if (expense.ProjectedAmount != null)
                            {
                                await _budgetItemService.AddBudgetItemAsync(expense, userId);
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
            var incomes = categories.Where(c => c.Type == "Income").Select(c => new BudgetItemDto { Name = c.Name, CategoryId = c.Id, TransactionType = MasterData.TransactionTypes.Income }).ToList();
            var expenses = categories.Where(c => c.Type == "Expense").Select(c => new BudgetItemDto { Name = c.Name, CategoryId = c.Id, TransactionType = MasterData.TransactionTypes.Expense }).ToList();

            var initialBudget = new InitialBudgetViewModel
            {
                Categories = categories,
                Incomes = incomes,
                Expenses = expenses
            };

            return View("Index",initialBudget);
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var existingBudgetItem = _db.BudgetItems.Where(x => x.UserId == user.Id).ToList();//TODO : Implement as service
                if(existingBudgetItem != null)
                {
                    var allCategories = await _db.Categories.ToListAsync();
                    var allIncomes = await _utilitiesService.GetIncomeCategoriesAsBudgetItemDtoAsync();
                    var allExpenses = await _utilitiesService.GetExpenseCategoriesAsBudgetItemAsync();
                    var existingBudgetItemDto = _budgetItemService.ConvertBudgetItemToDtoList(existingBudgetItem);

                    allIncomes = _utilitiesService
                        .MergeBudgetItems(allIncomes, existingBudgetItemDto
                        .Where(x => x.TransactionType == MasterData.TransactionTypes.Income)
                        .ToList());

                    allExpenses = _utilitiesService
                        .MergeBudgetItems(allExpenses, existingBudgetItemDto
                        .Where(x => x.TransactionType == MasterData.TransactionTypes.Expense)
                        .ToList());

                    var existingModel = new InitialBudgetViewModel
                    {
                        Categories = allCategories,
                        Incomes = allIncomes,
                        Expenses = allExpenses
                    };

                    return View(existingModel);

                }
                
            }
            var categories = await _db.Categories.ToListAsync(); 
            var incomes = await _utilitiesService.GetIncomeCategoriesAsBudgetItemDtoAsync(); 
            var expenses = await _utilitiesService.GetExpenseCategoriesAsBudgetItemAsync(); 

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
