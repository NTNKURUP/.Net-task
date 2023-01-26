using CustomerAPI.Models;

namespace CustomerAPI.Repository
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>list of customer</returns>
        public List<Customer> GetCustomers();

        /// <summary>
        /// Gets customer by id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Customer</returns>
        public Customer? GetCustomerById(int customerId);

        /// <summary>
        /// Adds a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>bool</returns>
        public bool AddCustomer(Customer customer);

        /// <summary>
        /// Edits a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>bool</returns>
        public bool EditCustomer(Customer customer);

        /// <summary>
        /// Checks if username is already taken
        /// </summary>
        /// <param name="username"></param>
        /// <returns>bool</returns>
        bool UsernameExists(Customer customer);
    }
}
