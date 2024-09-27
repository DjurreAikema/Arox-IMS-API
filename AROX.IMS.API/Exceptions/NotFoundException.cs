using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Exceptions;

public class NotFoundException(string message) : Exception(message)
{
    // Ensure customer exists
    public static async Task EnsureCustomerExists(AROX_IMSContext context, long customerId)
    {
        var customerExists = await context.Customers.AnyAsync(c => c.Id == customerId);
        if (!customerExists)
        {
            throw new NotFoundException($"Customer with Id {customerId} not found.");
        }
    }

    // Ensure application exists and return it if it does
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