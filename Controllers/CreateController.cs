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
        private readonly ICategoryService _categoryService;

        public CreateController(ApplicationDbContext context, 
                                UserManager<ApplicationUser> userManager,
                                ITransactionService incomeService,
                                IBudgetItemService expenseService,
                                IGoalService goalService,
                                IBalanceService balanceService,
                                IUtilitiesService utilitiesService,
                                ICategoryService categoryService)
        {
            _db = context;
            _userManager = userManager;
            _incomeService = incomeService;
            _budgetItemService = expenseService;
            _goalService = goalService;
            _balanceService = balanceService;
            _utilitiesService = utilitiesService;
            _categoryService = categoryService;
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
                                income.Name = await _categoryService
                                    .GetCategoryName(income.CategoryId.Value);

                                if(await _budgetItemService
                                    .CheckIfBudgetItemExist(userId, income.CategoryId.Value))
                                {
                                    await _budgetItemService
                                        .UpdateBudgetItemAsync(income, userId);
                                }
                                else
                                {
                                    await _budgetItemService
                                        .AddBudgetItemAsync(income, userId);
                                }
                            }
                        }

                        foreach (var expense in model.Expenses)
                        {
                            if (expense.ProjectedAmount != null)
                            {
                                expense.Name = await _categoryService
                                    .GetCategoryName(expense.CategoryId.Value);

                                if (await _budgetItemService
                                    .CheckIfBudgetItemExist(userId, expense.CategoryId.Value))
                                {
                                    await _budgetItemService
                                        .UpdateBudgetItemAsync(expense, userId);
                                }
                                else
                                {
                                    await _budgetItemService
                                        .AddBudgetItemAsync(expense, userId);
                                }
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
                    ModelState
                        .AddModelError("", "An error occurred while creating the budget. Please try again.");
                }
            }

            return RedirectToAction("Index");
            
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var incomeCategories = await _categoryService
                    .GetAllCategories(MasterData.CategoryTypes.Income);

            var expenseCategories = await _categoryService
                .GetAllCategories(MasterData.CategoryTypes.Expense);

            if (user != null)
            {
                // Obtener los ingresos y gastos ya creados para el usuario !TODO: Implementar como servicio
                var existingBudgetItems = await _db.BudgetItems
                    .Where(x => x.UserId == user.Id)
                    .ToListAsync();

                // Convertir `BudgetItems` a DTOs
                var existingBudgetItemDtos = _budgetItemService.ConvertBudgetItemToDtoList(existingBudgetItems);

                // Agrupar los ingresos y gastos
                var model = new InitialBudgetViewModel
                {
                    IncomeCategories = incomeCategories,
                    ExpenseCategories = expenseCategories,
                    Incomes = existingBudgetItemDtos
                        .Where(x => x.TransactionType == MasterData.TransactionTypes.Income)
                        .ToList(),
                    Expenses = existingBudgetItemDtos
                        .Where(x => x.TransactionType == MasterData.TransactionTypes.Expense)
                        .ToList()
                };

                return View(model);
            }

            // Si no hay usuario, devolver una vista con listas vacías
            return View(new InitialBudgetViewModel
            {
                IncomeCategories = incomeCategories,
                ExpenseCategories = expenseCategories,
                Incomes = new List<BudgetItemDto>(),
                Expenses = new List<BudgetItemDto>()
            });
        }


    }
}
