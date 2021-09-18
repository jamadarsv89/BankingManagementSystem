using BankingManagementSystem.Data.Interfaces;
using BankingManagementSystem.Data.Models;
using BankingManagementSystem.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingManagementSystem.Service.Services
{
    public class LoanService : ILoanService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly ILogger logger;

        public LoanService(IRepositoryWrapper _repositoryWrapper, ILogger<LoanService> _logger)
        {
            repositoryWrapper = _repositoryWrapper;
            logger = _logger;
        }

        public async Task ApplyForLoan(Loan loan)
        {
            await repositoryWrapper.Loan.CreateAsync(loan);

            await repositoryWrapper.SaveAsync();
        }

        public List<Loan> GetAllLoans(long customerId)
        {
            return repositoryWrapper.Loan.FindByCondition(l => l.CustomerId == customerId).ToList();
        }
    }
}
