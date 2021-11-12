using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using BankingManagementSystem.API.ApiModels.InputModel;
using BankingManagementSystem.API.ApiModels.OutputModel;
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
    public class CustomerControllerTest
    {
        [AutoData]
        [Theory]
        public async Task Post_ValidRequest_CreatesCustomer(IFixture fixture)
        {
            var customerInputModel = fixture.Build<CustomerInputModel>().Create();
            var logger = new Mock<ILogger<CustomerController>>();
            var mockCustomerService = new Mock<ICustomerService>();
            var mapper = new Mock<IMapper>();

            mockCustomerService.Setup(c => c.CreateCustomer(It.IsAny<Customer>())).Verifiable();

            var customerController = new CustomerController(mockCustomerService.Object, mapper.Object, logger.Object);

            await customerController.Post(customerInputModel);
        }

        [AutoData]
        [Theory]
        public void Get_ExistingCustomer_ReturnCustomer(IFixture fixture)
        {
            var customer = fixture.Build<Customer>().Without(c => c.Loans).Create();
            var logger = new Mock<ILogger<CustomerController>>();
            var mockCustomerService = new Mock<ICustomerService>();
            var mapper = new Mock<IMapper>();

            mockCustomerService.Setup(c => c.GetCustomer(It.IsAny<long>())).Returns(customer);

            var customerController = new CustomerController(mockCustomerService.Object, mapper.Object, logger.Object);

            var result = customerController.Get(customer.Id);

            Assert.NotNull(result);
        }
    }
}
