using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Helpers;
using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class ApplicationService(AROX_IMSContext context)
{
    // Get all applications
    public async Task<List<ApplicationDto>> GetApplications()
    {
        return await context.Applications
            .Select(x => ApplicationConverters.ToModel(x))
            .ToListAsync();
    }

    // Get application by id
    public async Task<ApplicationDto?> GetApplication(long id)
    {
        return await context.Applications
            .Where(x => x.Id == id)
            .Select(x => ApplicationConverters.ToModel(x))
            .FirstOrDefaultAsync();
    }

    // Add new application
    public async Task<ApplicationDto> AddApplication(NewApplicationDto application)
    {
        // Validate
        await NotFoundException.EnsureCustomerExists(context, application.CustomerId);

        // Add
        var newApplication = ApplicationConverters.ToEntity(application);
        context.Applications.Add(newApplication);
        await context.SaveChangesAsync();

        // Return
        return ApplicationConverters.ToModel(newApplication);
    }

    // Update application
    public async Task<ApplicationDto> UpdateApplication(ApplicationDto application)
    {
        // Validate
        var existingApplication = await NotFoundException.EnsureApplicationExists(context, application.Id);
        await NotFoundException.EnsureCustomerExists(context, application.CustomerId);

        // Update
        ApplicationConverters.UpdateEntity(existingApplication, application);
        context.Entry(existingApplication).State = EntityState.Modified;
        await context.SaveChangesAsync();

        // Return
        return ApplicationConverters.ToModel(existingApplication);
    }

    // Delete application
    public async Task<ApplicationDto> DeleteApplication(long id)
    {
        // Validate
        var application = await NotFoundException.EnsureApplicationExists(context, id);

        // Delete
        context.Applications.Remove(application);
        await context.SaveChangesAsync();

        // Return
        return ApplicationConverters.ToModel(application);
    }
}