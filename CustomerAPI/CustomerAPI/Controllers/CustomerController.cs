using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
    {
        var createdCustomer = await _customerService.CreateCustomerAsync(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id    = createdCustomer.CustomerId }, createdCustomer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCustomer(int id, [FromBody] Customer customer)
    {
        try
        {
            await _customerService.UpdateCustomerAsync(id, customer);
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        try
        {
            await _customerService.DeleteCustomerAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        return NoContent();
    }
}