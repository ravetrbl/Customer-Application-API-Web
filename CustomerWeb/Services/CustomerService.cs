using CustomerAPI.Models;

namespace CustomerWeb.Services
{
    public class CustomerService : ICustomerService 
    {
        private readonly HttpClient _httpClient;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("https://localhost:7198/api/customer");
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"https://localhost:7198/api/customer/{id}");
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7198/api/customer", customer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Customer>();
        }

        public async Task UpdateCustomerAsync(int customerId, Customer customer)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7198/api/customer/{customerId}", customer);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7198/api/customer/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
