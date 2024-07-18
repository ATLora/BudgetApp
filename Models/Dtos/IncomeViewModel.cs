﻿namespace BudgetApp.Models.Dtos
{
    public class IncomeViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? ProjectedAmount { get; set; }
        public decimal? RealAmount { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public bool IsRecurrent { get; set; }
        public int? SetRecurrentDay { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}