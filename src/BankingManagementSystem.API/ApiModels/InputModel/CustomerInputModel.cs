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

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(10)]
        public string PanNumber { get; set; }

        [Required]
        [Phone]
        [MaxLength(13)]
        public string ContactNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public AccountTypeEnum AccountType { get; set; }
    }
}
