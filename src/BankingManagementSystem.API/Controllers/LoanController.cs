using BankingManagementSystem.Data.Models;
using BankingManagementSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BankingManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost("ApplyForLoan")]
        public async Task<IActionResult> Post(Loan loan)
        {
            await loanService.ApplyForLoan(loan);

            return NoContent();
        }

        [HttpGet("{customerId}")]
        public IActionResult Get(long customerId)
        {
            return Ok(loanService.GetAllLoans(customerId));
        }
    }
}
