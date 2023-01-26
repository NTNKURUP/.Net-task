using CustomerAPI.Data;
using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        #region Fields
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;
        #endregion

        #region Public Methods
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            if (id == 0)
            {
                throw new BadRequestException("Customer id should be greater than 0");
            }

            var customer = _customerService.GetById(id);
            if(customer == null)
            {
                throw new NotFoundException("No customer data found");
            }

            return Ok(customer);
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult FetchCustomers()
        {
            var customers = _customerService.GetAll();

            if (customers == null || !customers.Any())
            {
                throw new NotFoundException("No customer records are found");
            }

            return Ok(customers);
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            CheckIfUsernameExists(customer);

            _customerService.AddCustomer(customer);
            return Ok();
        }

        [HttpPost("EditCustomer")]
        public IActionResult EditCustomer(Customer customer)
        {
            if (_customerService.GetById(customer.CustomerId) == null)
            {
                throw new NotFoundException("Customer not found");
            }

            CheckIfUsernameExists(customer);

            _customerService.EditCustomer(customer);
            return Ok();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check if the customer properties has values in them
        /// </summary>
        /// <param name="isEdit"></param>
        /// <param name="customer"></param>
        /// 
        /// 
        /// <returns></returns>
        private void CheckIfUsernameExists(Customer customer)
        {
            if (_customerService.UsernameExists(customer))
            {
                throw new BadRequestException("The Username is already taken");
            }
        }

        #endregion
    }
}
