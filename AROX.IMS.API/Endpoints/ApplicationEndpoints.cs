using AROX.IMS.API.Classes;
using AROX.IMS.API.Services;
using GeneralTools.AspNetCore.MinimalApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AROX.IMS.API.Endpoints;

public class ApplicationEndpoints : IMapEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        // Get all applications
        app.MapGet("api/applications", async (ApplicationService applicationService) =>
                Results.Ok((object?) await applicationService.GetApplications()))
            .WithTags("Application");

        // Get application by id
        app.MapGet("api/applications/{id:long}", async (ApplicationService applicationService, long id) =>
            {
                var application = await applicationService.GetApplication(id);
                return application == null ? Results.NotFound() : Results.Ok(application);
            })
            .WithTags("Application");

        // Add new application
        app.MapPost("api/applications", async (ApplicationService applicationService, ApplicationModel application) =>
                Results.Created("api/applications", await applicationService.AddApplication(application)))
            .WithTags("Application");

        // Update application
        app.MapPut("api/applications", async (ApplicationService applicationService, ApplicationModel application) =>
                Results.Ok((object?) await applicationService.UpdateApplication(application)))
            .WithTags("Application");

        // Delete application
        app.MapDelete("api/applications/{id:long}", async (ApplicationService applicationService, long id) =>
                Results.Ok((object?) await applicationService.DeleteApplication(id)))
            .WithTags("Application");
    }
}