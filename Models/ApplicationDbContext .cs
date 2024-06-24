using BudgetApp.Models.CoreModels;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Saving> Savings { get; set; }

    }
}
