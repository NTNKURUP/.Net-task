using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }
        public string Username { get; set; }

        public string Password { get;set; }
    }

}
