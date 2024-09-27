using AROX.IMS.API.Classes;
using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class CustomerService(AROX_IMSContext context)
{
    // Get all customers
    public async Task<List<CustomerModel>> GetCustomers()
    {
        return await context.Customers
            .Select(x => new CustomerModel
            {
                Id = x.Id,
                Name = x.Name,
            })
            .ToListAsync();
    }

    // Get customer by id
    public async Task<CustomerModel?> GetCustomer(long id)
    {
        return await context.Customers
            .Where(x => x.Id == id)
            .Select(x => new CustomerModel
            {
                Id = x.Id,
                Name = x.Name,
            })
            .FirstOrDefaultAsync();
    }

    // Add new customer
    public async Task<Customer> AddCustomer(Customer customer)
    {
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
        return customer;
    }

    // Update customer
    public async Task<Customer> UpdateCustomer(Customer customer)
    {
        context.Entry(customer).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return customer;
    }

    // Delete customer
    public async Task<Customer> DeleteCustomer(long id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
        return customer;
    }
}