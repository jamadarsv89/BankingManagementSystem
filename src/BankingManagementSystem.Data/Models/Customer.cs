using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingManagementSystem.Data.Models
{
    public class Customer
    {
        public long Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [MaxLength(10)]
        public string PanNumber { get; set; }

        [MaxLength(13)]
        public string ContactNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int AccountType { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
