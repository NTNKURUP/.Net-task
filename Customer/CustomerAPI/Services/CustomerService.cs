using CustomerAPI.Data;
using CustomerAPI.Models;
using CustomerAPI.Repository;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetCustomers();
        }


        public Customer GetById(int customerId)
        {
            return _customerRepository.GetCustomerById(customerId);
        }

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);

        }

        public bool EditCustomer(Customer customer)
        {
            return _customerRepository.EditCustomer(customer);
        }

        public bool UsernameExists(Customer customer)
        {
            return _customerRepository.UsernameExists(customer);
        }

    }
}
