using AROX.IMS.API.Classes;
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
    public async Task<ApplicationDto> AddApplication(ApplicationDto application)
    {
        var newApplication = ApplicationConverters.ToEntity(application);
        context.Applications.Add(newApplication);
        await context.SaveChangesAsync();

        return ApplicationConverters.ToModel(newApplication);
    }

    // Update application
    public async Task<ApplicationDto> UpdateApplication(ApplicationDto application)
    {
        var existingApplication = await context.Applications.FindAsync(application.Id);
        if (existingApplication == null) throw new Exception("Application not found");

        ApplicationConverters.UpdateEntity(existingApplication, application);
        context.Entry(existingApplication).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return ApplicationConverters.ToModel(existingApplication);
    }

    // Delete application
    public async Task<ApplicationDto> DeleteApplication(long id)
    {
        var application = await context.Applications.FindAsync(id);
        if (application == null) throw new Exception("Application not found");

        context.Applications.Remove(application);
        await context.SaveChangesAsync();

        return ApplicationConverters.ToModel(application);
    }
}