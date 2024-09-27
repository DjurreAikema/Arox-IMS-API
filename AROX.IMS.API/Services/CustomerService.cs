using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class CustomerService(AROX_IMSContext context)
{
    public async Task<List<Customer>> GetCustomers()
    {
        // Use EF to get customers from database
        return await context.Customers.ToListAsync();
    }
}