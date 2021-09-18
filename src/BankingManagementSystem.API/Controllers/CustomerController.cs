using AutoMapper;
using BankingManagementSystem.API.ApiModels.InputModel;
using BankingManagementSystem.API.ApiModels.OutputModel;
using BankingManagementSystem.Data.Models;
using BankingManagementSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BankingManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public CustomerController(ICustomerService _customerService, IMapper _mapper, ILogger<CustomerController> _logger)
        {
            customerService = _customerService;
            mapper = _mapper;
            logger = _logger;
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var customer = customerService.GetCustomer(id);

            if(customer == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CustomerModel>(customer));
        }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="customerInputModel"></param>
        /// <returns></returns>
        [HttpPost("RegisterCustomer")]
        public async Task<IActionResult> Post(CustomerInputModel customerInputModel)
        {
            await customerService.CreateCustomer(mapper.Map<Customer>(customerInputModel));

            return NoContent();
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerInputModel"></param>
        /// <returns></returns>
        [HttpPut("UpdateCustomerProfile/{id}")]
        public async Task<IActionResult> Put(long id, CustomerInputModel customerInputModel)
        {
            await customerService.UpdateCustomerInfo(id, mapper.Map<Customer>(customerInputModel));

            return NoContent();
        }
    }
}
