using BankingManagementSystem.Data;
using BankingManagementSystem.Data.Interfaces;
using BankingManagementSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankingManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public CustomerController(IRepositoryWrapper _repositoryWrapper)
        {
            repositoryWrapper = _repositoryWrapper;
        }

        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repositoryWrapper.Customer.FindAll());
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(repositoryWrapper.Customer.FindByCondition(c => c.Id == id));
        }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            await repositoryWrapper.Customer.CreateAsync(customer);

            await repositoryWrapper.SaveAsync();

            return NoContent();
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Customer customer)
        {
            repositoryWrapper.Customer.Update(customer);

            await repositoryWrapper.SaveAsync();

            return NoContent();
        }
    }
}
