using BankingManagementSystem.Data.Models;
using BankingManagementSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BankingManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService loanService;
        private readonly ILogger logger;

        public LoanController(ILoanService _loanService, ILogger<LoanController> _logger)
        {
            loanService = _loanService;
            logger = _logger;
        }

        /// <summary>
        /// Apply for loan
        /// </summary>
        /// <param name="loan"></param>
        /// <returns></returns>
        [HttpPost("ApplyForLoan")]
        public async Task<IActionResult> Post(Loan loan)
        {
            await loanService.ApplyForLoan(loan);

            return NoContent();
        }

        /// <summary>
        /// Get All loans for customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public IActionResult Get(long customerId)
        {
            return Ok(loanService.GetAllLoans(customerId));
        }
    }
}
