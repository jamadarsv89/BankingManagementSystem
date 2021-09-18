using BankingManagementSystem.API.ApiModels.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankingManagementSystem.API.ApiModels.InputModel
{
    public class CustomerInputModel
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
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

        [EmailAddress]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [MaxLength(10)]
        public string PanNumber { get; set; }

        [Phone]
        [MaxLength(13)]
        public string ContactNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public AccountTypeEnum AccountType { get; set; }
    }
}
