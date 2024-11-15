﻿using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models.Dtos
{
    public class BudgetItemDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Projected Amount")]
        public decimal? ProjectedAmount { get; set; }
        public decimal? RealAmount { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public bool IsRecurrent { get; set; }
        public int TransactionType { get; set; }
        public int? SetRecurrentDay { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
