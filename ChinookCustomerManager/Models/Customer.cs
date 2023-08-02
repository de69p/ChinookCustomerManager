using System.ComponentModel.DataAnnotations;

namespace ChinookCustomerManager.Models;

public class Customer
{
    public Customer(int customerId, string firstName, string lastName)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
    }

    public int CustomerId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
        
}

