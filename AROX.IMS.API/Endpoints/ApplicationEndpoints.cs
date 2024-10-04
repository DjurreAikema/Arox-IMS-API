using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
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
                try
                {
                    var application = await applicationService.GetApplication(id);
                    return application == null ? Results.NotFound() : Results.Ok(application);
                }
                catch (Exception e)
                {
                    return Results.Problem(e.Message);
                }
            })
            .WithTags("Application");

        // Add new application
        app.MapPost("api/applications", async (ApplicationService applicationService, NewApplicationDto application) =>
            {
                try
                {
                    var result = await applicationService.AddApplication(application);
                    return Results.Created("api/applications", result);
                }
                catch (NotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            })
            .WithTags("Application");

        // Update application
        app.MapPut("api/applications/{id:long}", async (ApplicationService applicationService, long id, ApplicationDto application) =>
            {
                try
                {
                    var result = await applicationService.UpdateApplication(id, application);
                    return Results.Ok(result);
                }
                catch (NotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            })
            .WithTags("Application");

        // Delete application
        app.MapDelete("api/applications/{id:long}", async (ApplicationService applicationService, long id) =>
            {
                try
                {
                    var result = await applicationService.DeleteApplication(id);
                    return Results.Ok(result);
                }
                catch (NotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            })
            .WithTags("Application");
    }
}