using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class FinancialTransaction
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TransactionType { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        // Additional properties related to financial transactions
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
