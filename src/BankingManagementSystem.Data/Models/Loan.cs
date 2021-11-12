using System;

namespace BankingManagementSystem.Data.Models
{
    public class Loan
    {
        public long Id { get; set; }

        public int LoanType { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateApplied { get; set; }

        public double InterestRate { get; set; }

        public double Duration { get; set; }

        public Customer Customer { get; set; }

        public long CustomerId { get; set; }
    }
}
