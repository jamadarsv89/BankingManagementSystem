using BankingManagementSystem.Data.Interfaces;
using BankingManagementSystem.Data.Models;
using BankingManagementSystem.Service.Helpers;
using BankingManagementSystem.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace BankingManagementSystem.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IConfiguration configuration;
        private readonly ILogger logger;

        public CustomerService(IRepositoryWrapper _repositoryWrapper, IConfiguration _configuration, ILogger<CustomerService> _logger)
        {
            repositoryWrapper = _repositoryWrapper;
            configuration = _configuration;
            logger = _logger;
        }

        public async Task CreateCustomer(Customer customer)
        {
            customer.Password = EncryptionHelper.Encrypt(customer.Password,
                configuration.GetValue<string>("AppSettings:PassPhrase"),
                configuration.GetValue<string>("AppSettings:Salt"),
                configuration.GetValue<string>("AppSettings:InitVector"));

            await repositoryWrapper.Customer.CreateAsync(customer);

            await repositoryWrapper.SaveAsync();
        }

        public Customer GetCustomer(long customerId)
        {
            return repositoryWrapper.Customer.FindByCondition(c => c.Id == customerId).ToList().FirstOrDefault();
        }

        public Customer GetCustomerByUserNameAndPassword(string username, string password)
        {
            return repositoryWrapper.Customer.FindByCondition(c => c.UserName == username && c.Password == password).ToList().FirstOrDefault();
        }

        public async Task UpdateCustomerInfo(long customerId, Customer customer)
        {
            var currentData = repositoryWrapper.Customer.FindByCondition(c => c.Id == customerId).ToList().FirstOrDefault();

            if(currentData == null)
            {
                throw new System.Exception("Not found");
            }

            if(customerId != customer.Id)
            {
                customer.Id = customerId;
            }

            var password = EncryptionHelper.Decrypt(currentData.Password,
                configuration.GetValue<string>("AppSettings:PassPhrase"),
                configuration.GetValue<string>("AppSettings:Salt"),
                configuration.GetValue<string>("AppSettings:InitVector"));

            if(password != customer.Password)
            {
                customer.Password = EncryptionHelper.Encrypt(customer.Password,
                    configuration.GetValue<string>("AppSettings:PassPhrase"),
                    configuration.GetValue<string>("AppSettings:Salt"),
                    configuration.GetValue<string>("AppSettings:InitVector"));
            }

            repositoryWrapper.Customer.Update(customer);

            await repositoryWrapper.SaveAsync();
        }
    }
}
