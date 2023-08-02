using Microsoft.AspNetCore.Mvc;
using ChinookCustomerManager.Data;
using ChinookCustomerManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ChinookCustomerManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ChinookContext _context;

    public CustomersController(ChinookContext context)
    {
        _context = context;
    }

    // GET: api/Customers
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        return _context.Customers.ToList();
    }
        
    // GET: api/Customers/5
    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomer(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }
        return customer;
    }

    // PUT: api/Customers/5
    [HttpPut("{id}")]
    public IActionResult PutCustomer(int id, Customer customer)
    {
        if (id != customer.CustomerId)
        {
            return BadRequest();
        }

        _context.Entry(customer).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // POST: api/Customers
    [HttpPost]
    public ActionResult<Customer> PostCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
    }

    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customer);
        _context.SaveChanges();

        return NoContent();
    }
}