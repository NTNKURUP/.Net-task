using AutoFixture;
using CustomerAPI.Controllers;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using FakeItEasy;
using FluentAssertions;

namespace Customer.Test
{
    public class CustomerControllerTest
    {
        private readonly ICustomerService _customerServiceMock;
        private readonly ILogger<CustomerController> _loggerMock;
        private readonly CustomerController _customerController;

        public CustomerControllerTest()
        {
            _customerServiceMock = A.Fake<ICustomerService>();
            _loggerMock = A.Fake<ILogger<CustomerController>>();

            _customerController = new CustomerController(_customerServiceMock, _loggerMock);
        }

        [Fact]
        public void GetAllCustomers_WithList_ShouldReturn_OK()
        {

            var customersMock = A.Fake<List<CustomerAPI.Models.Customer>>();
            customersMock.Add(new CustomerAPI.Models.Customer() { Firstname = "test1", Surname = "test2", Username = "test12", Password = "test123" });
            A.CallTo(() => _customerServiceMock.GetAll()).Returns(customersMock);

            var actionResult = _customerController.FetchCustomers();

            var result = actionResult as OkObjectResult;

            var returnCustomers = result?.Value as List<CustomerAPI.Models.Customer>;

            Assert.Equal(customersMock.Count, returnCustomers?.Count);
        }

        [Fact]
        public void Add_Customers_ShouldReturn_OK()
        {
            var customer = A.Fake<CustomerAPI.Models.Customer>();

            customer.Firstname = "Test";
            customer.Surname = "User";
            customer.Username = "test_user";
            customer.Password = "test123";

            var result = _customerController.AddCustomer(customer);

            result.Should().BeOfType(typeof(OkResult));
        }

    }
}