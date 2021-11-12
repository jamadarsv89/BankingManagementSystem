using AutoFixture;
using AutoFixture.Xunit2;
using BankingManagementSystem.Data.Interfaces;
using BankingManagementSystem.Data.Models;
using BankingManagementSystem.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingManagementSystem.Data.Test
{
    public class LoanServiceTest
    {
        [AutoData]
        [Theory]
        public async Task ApplyForLoan_ValidRequest_CreatesLoan(IFixture fixture)
        {
            var loan = fixture.Build<Loan>().Without(l => l.Customer).Create();
            var logger = new Mock<ILogger<LoanService>>();
            var mockRespositoryWrapper = new Mock<IRepositoryWrapper>();
            var applicationContext = new Mock<ApplicationContext>();

            var mockLoanRespository = new Mock<ILoanRepository>();

            mockLoanRespository.Setup(r => r.CreateAsync(It.IsAny<Loan>())).Verifiable();

            mockRespositoryWrapper.Setup(r => r.Loan).Returns(mockLoanRespository.Object);

            var customerService = new LoanService(mockRespositoryWrapper.Object, logger.Object);

            await customerService.ApplyForLoan(loan);

            mockRespositoryWrapper.Verify(r => r.Loan.CreateAsync(loan), Times.Once);
        }

        [AutoData]
        [Theory]
        public void GetAllLoans_ExistingLoan_GetLoans(IFixture fixture)
        {
            var loan = fixture.Build<Loan>().Without(l => l.Customer).Create();
            var logger = new Mock<ILogger<LoanService>>();
            var mockRespositoryWrapper = new Mock<IRepositoryWrapper>();
            var applicationContext = new Mock<ApplicationContext>();

            var mockLoanRespository = new Mock<ILoanRepository>();
            var mockLoan = new List<Loan>() { loan }.AsQueryable();

            mockLoanRespository.Setup(r => r.FindByCondition(It.IsAny<Expression<Func<Loan, bool>>>())).Returns(mockLoan);

            mockRespositoryWrapper.Setup(r => r.Loan).Returns(mockLoanRespository.Object);

            var customerService = new LoanService(mockRespositoryWrapper.Object, logger.Object);

            var loans = customerService.GetAllLoans(loan.CustomerId);

            Assert.NotNull(loans);
        }
    }
}
