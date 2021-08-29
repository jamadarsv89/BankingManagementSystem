using BankingManagementSystem.Data.Interfaces;
using BankingManagementSystem.Data.Models;

namespace BankingManagementSystem.Data.Repository
{
    public class LoanRepository : RepositoryBase<Loan>, ILoanRepository
    {
        public LoanRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
