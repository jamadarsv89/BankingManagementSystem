using AutoFixture;
using AutoFixture.Xunit2;
using BankingManagementSystem.Data.Interfaces;
using BankingManagementSystem.Data.Models;
using BankingManagementSystem.Data.Repository;
using BankingManagementSystem.Service.Interfaces;
using BankingManagementSystem.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace BankingManagementSystem.Data.Test
{
    public class CustomerServiceTest
    {
        [AutoData]
        [Theory]
        public async Task CreateCustomer_ValidRequest_CreatesCustomer(IFixture fixture)
        {
            var customer = fixture.Build<Customer>().Without(c => c.Loans).Create();
            var logger = new Mock<ILogger<CustomerService>>();
            var mockRespositoryWrapper = new Mock<IRepositoryWrapper>();
            var applicationContext = new Mock<ApplicationContext>();

            var myConfiguration = new Dictionary<string, string>
            {
                {"AppSettings:PassPhrase", "bxwD5j4LK4NEvlakuPp1g=="},
                {"AppSettings:Salt", "JU=JVGLSFSgN4=!-LW"},
                {"AppSettings:InitVector", "H2+_=S*QFA=P!Gu_"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();

            var mockCustomerRespository = new Mock<ICustomerRepository>();

            mockCustomerRespository.Setup(r => r.CreateAsync(It.IsAny<Customer>())).Verifiable();

            mockRespositoryWrapper.Setup(r => r.Customer).Returns(mockCustomerRespository.Object);

            var customerService = new CustomerService(mockRespositoryWrapper.Object, configuration, logger.Object);

            await customerService.CreateCustomer(customer);

            mockRespositoryWrapper.Verify(r => r.Customer.CreateAsync(customer), Times.Once);
        }

        [AutoData]
        [Theory]
        public void CreateCustomer_ExistingRecord_ReturnsCustomer(IFixture fixture)
        {
            var customer = fixture.Build<Customer>().Without(c => c.Loans).Create();
            var logger = new Mock<ILogger<CustomerService>>();
            var mockRespositoryWrapper = new Mock<IRepositoryWrapper>();
            var applicationContext = new Mock<ApplicationContext>();

            var myConfiguration = new Dictionary<string, string>
            {
                {"AppSettings:PassPhrase", "bxwD5j4LK4NEvlakuPp1g=="},
                {"AppSettings:Salt", "JU=JVGLSFSgN4=!-LW"},
                {"AppSettings:InitVector", "H2+_=S*QFA=P!Gu_"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();

            var mockCustomerRespository = new Mock<ICustomerRepository>();
            var customerId = 1234;
            var _mockedCustomerQuery = (new List<Customer> { new Fixture().Build<Customer>().With(c => c.Id, customerId).Without(c => c.Loans).Create() }).AsQueryable();//new Mock<IQueryable<Customer>>();

            mockCustomerRespository.Setup(r => r.FindByCondition(It.IsAny<Expression<Func<Customer,bool>>>())).Returns(_mockedCustomerQuery);

            mockRespositoryWrapper.Setup(r => r.Customer).Returns(mockCustomerRespository.Object);

            var customerService = new CustomerService(mockRespositoryWrapper.Object, configuration, logger.Object);

            var result = customerService.GetCustomer(customerId);

            Assert.NotNull(result);
        }

        [AutoData]
        [Theory]
        public void GetCustomerByUserNameAndPassword_ExistingRecord_ReturnsCustomer(IFixture fixture)
        {
            var customer = fixture.Build<Customer>().Without(c => c.Loans).Create();
            var logger = new Mock<ILogger<CustomerService>>();
            var mockRespositoryWrapper = new Mock<IRepositoryWrapper>();
            var applicationContext = new Mock<ApplicationContext>();

            var myConfiguration = new Dictionary<string, string>
            {
                {"AppSettings:PassPhrase", "bxwD5j4LK4NEvlakuPp1g=="},
                {"AppSettings:Salt", "JU=JVGLSFSgN4=!-LW"},
                {"AppSettings:InitVector", "H2+_=S*QFA=P!Gu_"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();

            var mockCustomerRespository = new Mock<ICustomerRepository>();
            var username = "username";
            var password = "password";
            var _mockedCustomerQuery = (new List<Customer> { new Fixture().Build<Customer>()
                .With(c => c.UserName, username)
                .With(c => c.Password, password)
                .Without(c => c.Loans).Create() }).AsQueryable();

            mockCustomerRespository.Setup(r => r.FindByCondition(It.IsAny<Expression<Func<Customer, bool>>>())).Returns(_mockedCustomerQuery);

            mockRespositoryWrapper.Setup(r => r.Customer).Returns(mockCustomerRespository.Object);

            var customerService = new CustomerService(mockRespositoryWrapper.Object, configuration, logger.Object);

            var result = customerService.GetCustomerByUserNameAndPassword(username, password);

            Assert.NotNull(result);
        }
    }
}
