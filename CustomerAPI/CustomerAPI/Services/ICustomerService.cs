using CustomerAPI.Models;

namespace CustomerAPI.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(int id, Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
