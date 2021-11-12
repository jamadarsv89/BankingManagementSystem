using BankingManagementSystem.Data.Interfaces;
using System.Threading.Tasks;

namespace BankingManagementSystem.Data.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _applicationContext;
        private ICustomerRepository _customerRepository;
        private ILoanRepository _loanRepository;

        public RepositoryWrapper(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public ICustomerRepository Customer
        {
            get
            {
                if(_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_applicationContext);
                }

                return _customerRepository;
            }
        }

        public ILoanRepository Loan
        {
            get
            {
                if(_loanRepository == null)
                {
                    _loanRepository = new LoanRepository(_applicationContext);
                }
                return _loanRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
