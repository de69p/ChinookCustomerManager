using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp;

class Program
{
    private static readonly HttpClient Client = new();

    static async Task Main()
    {
        // Set the base address of the API
        Client.BaseAddress = new Uri("http://localhost:5000");

        // Get all customers
        await GetCustomers();

        // Get a single customer
        await GetCustomer(4);

        // Create a new customer
        var customer = new Customer
        {
            // Initialize your customer here
        };
        await CreateCustomer(customer);

        // Update a customer
        var updatedCustomer = new Customer
        {
            // Update your customer here
        };
        await UpdateCustomer(2, updatedCustomer);

        // Delete a customer
        await DeleteCustomer(2); 
    }

    private static async Task GetCustomers()
    {
        Console.WriteLine("Executing GET /api/Customers");
        HttpResponseMessage response = await Client.GetAsync("/api/Customers");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        var customers = JsonConvert.DeserializeObject<List<Customer>>(responseBody);

        if (customers != null)
            foreach (var customer in customers)
            {
                Console.WriteLine(
                    $"ID: {customer.CustomerId}, FirstName: {customer.FirstName}, LastName: {customer.LastName}");
            }
    }


    private static async Task GetCustomer(int id)
    {
        Console.WriteLine($"Executing GET /api/Customers/{id}");
        HttpResponseMessage response = await Client.GetAsync($"/api/Customers/{id}");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
    }

    private static async Task CreateCustomer(Customer customer)
    {
        Console.WriteLine("Executing POST /api/Customers");
        var json = JsonConvert.SerializeObject(customer);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await Client.PostAsync("/api/Customers", data);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
    }

    private static async Task UpdateCustomer(int id, Customer customer)
    {
        Console.WriteLine($"Executing PUT /api/Customers/{id}");
        var json = JsonConvert.SerializeObject(customer);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await Client.PutAsync($"/api/Customers/{id}", data);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
    }

    private static async Task DeleteCustomer(int id)
    {
        Console.WriteLine($"Executing DELETE /api/Customers/{id}");
        HttpResponseMessage response = await Client.DeleteAsync($"/api/Customers/{id}");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
    }

}