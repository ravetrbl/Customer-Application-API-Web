using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; } 
        public string ContactNumber { get; set; } 
    }
}