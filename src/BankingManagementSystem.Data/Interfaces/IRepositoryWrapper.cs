using System.Threading.Tasks;

namespace BankingManagementSystem.Data.Interfaces
{
    public interface IRepositoryWrapper
    {        
        ICustomerRepository Customer { get; }
        ILoanRepository Loan { get; }
        Task SaveAsync();
    }
}
