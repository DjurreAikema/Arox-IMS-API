using AROX.IMS.API.Classes;
using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class ApplicationService(AROX_IMSContext context)
{
    // Get all applications
    public async Task<List<Application>> GetApplications()
    {
        return await context.Applications.ToListAsync();
    }

    // Get application by id
    public async Task<Application?> GetApplication(long id)
    {
        return await context.Applications
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
    }

    // Add new application
    public async Task<Application> AddApplication(ApplicationModel application)
    {
        var newApplication = new Application { Name = application.Name, CustomerId = application.CustomerId };
        context.Applications.Add(newApplication);
        await context.SaveChangesAsync();
        return newApplication;
    }

    // Update application
    public async Task<Application> UpdateApplication(ApplicationModel application)
    {
        var existingApplication = await context.Applications.FindAsync(application.Id);
        if (existingApplication == null) throw new Exception("Application not found");

        existingApplication.Name = application.Name;
        context.Entry(existingApplication).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return existingApplication;
    }

    // Delete application
    public async Task<Application> DeleteApplication(long id)
    {
        var application = await context.Applications.FindAsync(id);
        if (application == null) throw new Exception("Application not found");

        context.Applications.Remove(application);
        await context.SaveChangesAsync();
        return application;
    }
}