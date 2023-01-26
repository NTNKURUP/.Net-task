using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CustomerAPI.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Customerdb");
        }
        public DbSet<Customer> Customers { get; set; }

    }
}