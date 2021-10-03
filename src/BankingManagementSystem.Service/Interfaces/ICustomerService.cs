using BankingManagementSystem.Data.Models;
using System.Threading.Tasks;

namespace BankingManagementSystem.Service.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomer(Customer customer);

        Task UpdateCustomerInfo(long customerId, Customer customer);

        Customer GetCustomer(long customerId);

        Customer GetCustomerByUserNameAndPassword(string customerId, string password);
    }
}
