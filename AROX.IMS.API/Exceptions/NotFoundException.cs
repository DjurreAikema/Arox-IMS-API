using IMS.EF.Models;

namespace AROX.IMS.API.Exceptions;

public class NotFoundException(string message) : Exception(message)
{
    // Ensure customer exists, and return it if it does
    public static async Task<Customer> EnsureCustomerExists(AROX_IMSContext context, long customerId)
    {
        var customer = await context.Customers.FindAsync(customerId);

        if (customer == null)
        {
            throw new NotFoundException($"Customer with Id {customerId} not found.");
        }

        return customer;
    }

    // Ensure application exists, and return it if it does
    public static async Task<Application> EnsureApplicationExists(AROX_IMSContext context, long applicationId)
    {
        var application = await context.Applications.FindAsync(applicationId);

        if (application == null)
        {
            throw new NotFoundException($"Application with Id {applicationId} not found.");
        }

        return application;
    }
}