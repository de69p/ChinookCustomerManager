using Microsoft.EntityFrameworkCore;
using ChinookCustomerManager.Models;

namespace ChinookCustomerManager.Data;

public class ChinookContext : DbContext
{
    public ChinookContext(DbContextOptions<ChinookContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}