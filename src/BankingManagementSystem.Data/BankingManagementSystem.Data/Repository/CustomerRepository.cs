using BankingManagementSystem.Data.Interfaces;
using BankingManagementSystem.Data.Models;

namespace BankingManagementSystem.Data.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
