using Microsoft.AspNetCore.Mvc;
using CustomerAPI.Models;
using CustomerWeb.Services;

public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IActionResult> Index()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return View(customers);
    }

    public async Task<IActionResult> Details(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null) return NotFound();
        return View(customer);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            await _customerService.CreateCustomerAsync(customer);
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null) return NotFound();
        return View(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Customer customer)
    {
        if (ModelState.IsValid)
        {
            await _customerService.UpdateCustomerAsync(id, customer);
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null) return NotFound();
        return View(customer);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
