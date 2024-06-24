using Microsoft.EntityFrameworkCore;
using System;
using BudgetApp.Models.CoreModels; 


namespace BudgetApp.Models.DataSeeding
{
    public static class CategoriesSeeding
    {
        public static void InitializeCategories(IServiceProvider serviceProvider)
        {
            using (var db = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var Expense = "Expense";
                var Income = "Income";
                var Saving = "Saving";
                var fasolid = "fa solid ";
                if (db.Categories.Any())
                {
                    return;   
                }
                else
                {
                    db.Categories.AddRange(
                        new Category
                        {
                            Name = "Food",
                            Type = Expense,
                            Icon = fasolid + "fa-burger-soda"
                        },
                        new Category
                        {
                            Name = "Housing",
                            Type = Expense,
                            Icon = fasolid + "fa-house"
                        },
                        new Category
                        {
                            Name = "Utilities",
                            Type = Expense,
                            Icon = fasolid + "fa-plug-circle-bolt"
                        },
                        new Category
                        {
                            Name = "Transport",
                            Type = Expense,
                            Icon = fasolid + "fa-train-subway"
                        },
                        new Category
                        {
                            Name = "Car",
                            Type = Expense,
                            Icon = fasolid + "fa-car"
                        },
                        new Category
                        {
                            Name = "Streaming",
                            Type = Expense,
                            Icon = fasolid + "fa-tv"
                        },
                        new Category
                        {
                            Name = "Entertainment",
                            Type = Expense,
                            Icon = fasolid + "fa-champagne-glases"
                        },
                        new Category
                        {
                            Name = "Clothing",
                            Type = Expense,
                            Icon = fasolid + "fa-shirt"
                        },
                        new Category
                        {
                            Name = "Medical/Healthcare",
                            Type = Expense,
                            Icon = fasolid + "fa-suitcase-medical"
                        },
                        new Category
                        {
                            Name = "Fitness",
                            Type = Expense,
                            Icon = fasolid + "fa-dumbbel"
                        },
                        new Category
                        {
                            Name = "Personal Care",
                            Type = Expense,
                            Icon = fasolid + "fa-face-smile-beam"
                        },
                        new Category
                        {
                            Name = "Debt",
                            Type = Expense,
                            Icon = fasolid + "fa-money-check-dollar"
                        },
                        new Category
                        {
                            Name = "Education",
                            Type = Expense,
                            Icon = fasolid + "fa-graduation-cap"
                        },
                        new Category
                        {
                            Name = "Gift/Donations",
                            Type = Expense,
                            Icon = fasolid + "fa-gift"
                        },
                        new Category
                        {
                            Name = "Household Items/Supplies",
                            Type = Expense,
                            Icon = fasolid + "fa-cart-shopping"
                        },
                        new Category
                        {
                            Name = "Shopping",
                            Type = Expense,
                            Icon = fasolid + "fa-bag-shopping"
                        },
                        new Category
                        {
                            Name = "Savings",
                            Type = Saving,
                            Icon = fasolid + "fa-piggy-bank"
                        },
                        new Category
                        {
                            Name = "Salary",
                            Type = Income,
                            Icon = fasolid + "fa-dollar-sign"
                        },
                        new Category
                        {
                            Name = "Sells",
                            Type = Income,
                            Icon = fasolid + "fa-dollar-sign"
                        },
                        new Category
                        {
                            Name = "Resnt",
                            Type = Income,
                            Icon = fasolid + "fa-dollar-sign"
                        },
                        new Category
                        {
                            Name = "Investments",
                            Type = Income,
                            Icon = fasolid + "fa-dollar-sign"
                        }
                        );
                    db.SaveChanges();
                }
            }
        }
    }
}
