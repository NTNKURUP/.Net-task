using CustomerAPI.Data;
using CustomerAPI.Models;
using CustomerAPI.Repository;
using Microsoft.EntityFrameworkCore;
namespace CustomerAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository()
        {

            using (var context = new DataContext())
            {
                if (!context.Customers.Any())
                {
                    var customers = new List<Customer>
                {
                    new Customer
                    {
                        Firstname ="Silvia",
                        Surname ="Nathen",
                        Username = "silnat",
                        Password = "abc"

                    },
                    new Customer
                    {
                        Firstname ="Jacob",
                        Surname ="John",
                        Username = "jjohn",
                        Password = "xyz"

                    },
                };
                    context.Customers.AddRange(customers);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>list of customer</returns>
        public List<Customer> GetCustomers()
        {
            using (var context = new DataContext())
            {
                return context.Customers.ToList();
            }
        }

        /// <summary>
        /// Gets customer by id
        /// </summary>
        /// <returns>Customer</returns>
        public Customer? GetCustomerById(int customerId)
        {
            using (var context = new DataContext())
            {
                return context.Customers?.Find(customerId);
            }
        }

        /// <summary>
        /// Adds a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>bool</returns>
        public bool AddCustomer(Customer customer)
        {
            using (var context = new DataContext())
            {
                context.Customers.Add(customer);
                int value = context.SaveChanges();
                return value > 0;
            }
        }

        /// <summary>
        /// Edits a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>bool</returns>
        public bool EditCustomer(Customer customer)
        {
            using (var context = new DataContext())
            {
                context.Customers.Update(customer);
                int value = context.SaveChanges();
                return value > 0;
            }
        }

        /// <summary>
        /// Checks if username is already taken
        /// CustomerId>0 means edit, should check if the username is used by some other customer other than this user 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>bool</returns>
        public bool UsernameExists(Customer customer)
        {
            using (var context = new DataContext())
            {
                var count = customer.CustomerId > 0 ? context.Customers.Count(x => x.Username == customer.Username && x.CustomerId != customer.CustomerId) :
                            context.Customers.Count(x => x.Username == customer.Username);
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
