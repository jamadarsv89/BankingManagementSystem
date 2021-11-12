using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using BankingManagementSystem.API.Controllers;
using BankingManagementSystem.Data.Models;
using BankingManagementSystem.Service.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingManagementSystem.API.Test
{
    public class LoanControllerTest
    {
        [AutoData]
        [Theory]
        public async Task Post_ValidRequest_CreatesLoan(IFixture fixture)
        {
            var loanInputModel = fixture.Build<Loan>().Without(l => l.Customer).Create();
            var logger = new Mock<ILogger<LoanController>>();
            var mockLoanService = new Mock<ILoanService>();
            var mapper = new Mock<IMapper>();

            mockLoanService.Setup(c => c.ApplyForLoan(It.IsAny<Loan>())).Verifiable();

            var customerController = new LoanController(mockLoanService.Object, logger.Object);

            await customerController.Post(loanInputModel);
        }

        [AutoData]
        [Theory]
        public void Get_ExistingCustomer_ReturnCustomer(IFixture fixture)
        {
            var loan = fixture.Build<Loan>().Without(l => l.Customer).Create();
            var logger = new Mock<ILogger<LoanController>>();
            var mockCustomerService = new Mock<ILoanService>();
            var mapper = new Mock<IMapper>();

            mockCustomerService.Setup(c => c.GetAllLoans(It.IsAny<long>())).Returns(new List<Loan>() { loan });

            var customerController = new LoanController(mockCustomerService.Object, logger.Object);

            var result = customerController.Get(loan.CustomerId);

            Assert.NotNull(result);
        }
    }
}
