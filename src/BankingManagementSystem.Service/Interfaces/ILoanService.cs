using BankingManagementSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingManagementSystem.Service.Interfaces
{
    public interface ILoanService
    {
        Task ApplyForLoan(Loan loan);

        List<Loan> GetAllLoans(long customerId);
    }
}
