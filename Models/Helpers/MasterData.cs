using BudgetApp.Models.CoreModels;

namespace BudgetApp.Models.Helpers
{
    public class MasterData
    {
        public static class TransactionTypes
        {
            public const int Expense = 1;
            public const int Income = 2;
            public const int Savings = 3;
        }

        public static class CategoryTypes
        {
            public const string Expense = "Expense";
            public const string Income = "Income";
            public const string Saving = "Saving";
        }
    }
}
