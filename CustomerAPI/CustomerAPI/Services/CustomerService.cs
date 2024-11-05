using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _context;

        public CustomerService(CustomerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateCustomerAsync(int customerId, Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customerId);
            if (existingCustomer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customerId} not found.");
            }

            existingCustomer.FullName = customer.FullName;
            existingCustomer.Birthdate = customer.Birthdate;
            existingCustomer.Gender = customer.Gender;
            existingCustomer.Address = customer.Address;
            existingCustomer.ContactNumber = customer.ContactNumber;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                throw new KeyNotFoundException("Customer not found");

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
