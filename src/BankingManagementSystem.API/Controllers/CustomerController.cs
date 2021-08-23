using BankingManagementSystem.Data;
using BankingManagementSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationContext _dbContext;

        public CustomerController(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Customers);
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_dbContext.Customers.Find(id));
        }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            _dbContext.Customers.Add(customer);

            _dbContext.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(long id, Customer customer)
        {
            _dbContext.Customers.Update(customer);

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
