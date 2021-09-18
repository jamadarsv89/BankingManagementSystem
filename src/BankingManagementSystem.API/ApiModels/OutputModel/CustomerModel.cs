using BankingManagementSystem.API.ApiModels.Shared;
using System;

namespace BankingManagementSystem.API.ApiModels.OutputModel
{
    public class CustomerModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string EmailAddress { get; set; }

        public string PanNumber { get; set; }

        public string ContactNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public AccountTypeEnum AccountType { get; set; }
    }
}
