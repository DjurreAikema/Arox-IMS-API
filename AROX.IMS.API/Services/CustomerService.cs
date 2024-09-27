using AROX.IMS.API.Classes;
using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class CustomerService(AROX_IMSContext context)
{
    // Get all customers
    public async Task<List<Customer>> GetCustomers()
    {
        return await context.Customers
            .Select(c => new Customer { Id = c.Id, Name = c.Name })
            .ToListAsync();
    }

    // Get customer by id
    public async Task<Customer?> GetCustomer(long id)
    {
        return await context.Customers
            .Where(c => c.Id == id)
            .Select(c => new Customer { Id = c.Id, Name = c.Name })
            .FirstOrDefaultAsync();
    }

    // Add new customer
    public async Task<Customer> AddCustomer(CustomerModel customer)
    {
        var newCustomer = new Customer { Name = customer.Name };
        context.Customers.Add(newCustomer);
        await context.SaveChangesAsync();
        return newCustomer;
    }

    // Update customer
    public async Task<Customer> UpdateCustomer(CustomerModel customer)
    {
        var existingCustomer = await context.Customers.FindAsync(customer.Id);
        if (existingCustomer == null) throw new Exception("Customer not found");

        existingCustomer.Name = customer.Name;
        context.Entry(existingCustomer).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return existingCustomer;
    }

    // Delete customer
    public async Task<Customer> DeleteCustomer(long id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null) throw new Exception("Customer not found");

        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
        return customer;
    }
}