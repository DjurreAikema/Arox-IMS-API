using AROX.IMS.API.Classes;
using AROX.IMS.API.Helpers;
using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class CustomerService(AROX_IMSContext context)
{
    // Get all customers
    public async Task<List<CustomerDto>> GetCustomers()
    {
        return await context.Customers
            .Select(x => CustomerConverters.ToModel(x))
            .ToListAsync();
    }

    // Get customer by id
    public async Task<CustomerDto?> GetCustomer(long id)
    {
        return await context.Customers
            .Where(x => x.Id == id)
            .Select(x => CustomerConverters.ToModel(x))
            .FirstOrDefaultAsync();
    }

    // Add new customer
    public async Task<CustomerDto> AddCustomer(NewCustomerDto customer)
    {
        var newCustomer = CustomerConverters.ToEntity(customer);
        context.Customers.Add(newCustomer);
        await context.SaveChangesAsync();

        return CustomerConverters.ToModel(newCustomer);
    }

    // Update customer
    public async Task<CustomerDto> UpdateCustomer(CustomerDto customer)
    {
        var existingCustomer = await context.Customers.FindAsync(customer.Id);
        if (existingCustomer == null) throw new Exception("Customer not found");

        CustomerConverters.UpdateEntity(existingCustomer, customer);
        context.Entry(existingCustomer).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return CustomerConverters.ToModel(existingCustomer);
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