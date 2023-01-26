using CustomerAPI.Models;

namespace CustomerAPI.Services
{
    public interface ICustomerService
    {
        public List<Customer> GetAll();
        public Customer GetById(int customerId);
        public bool AddCustomer(Customer customer);
        public bool EditCustomer(Customer customer);
        public bool UsernameExists(Customer customer);
    }
}
