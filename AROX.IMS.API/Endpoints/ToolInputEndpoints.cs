using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Services;
using GeneralTools.AspNetCore.MinimalApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AROX.IMS.API.Endpoints;

public class ToolInputEndpoints : IMapEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        // Get all tool inputs
        app.MapGet("api/toolinputs", async (ToolInputService toolInputService) =>
                Results.Ok((object?) await toolInputService.GetToolInputs()))
            .WithTags("ToolInput");

        // Get tool input by id
        app.MapGet("api/toolinputs/{id:long}", async (ToolInputService toolInputService, long id) =>
            {
                try
                {
                    var toolInput = await toolInputService.GetToolInput(id);
                    return toolInput == null ? Results.NotFound() : Results.Ok(toolInput);
                }
                catch (Exception e)
                {
                    return Results.Problem(e.Message);
                }
            })
            .WithTags("ToolInput");

        // Add new tool input
        app.MapPost("api/toolinputs", async (ToolInputService toolInputService, NewToolInputDto toolInput) =>
            {
                try
                {
                    var result = await toolInputService.AddToolInput(toolInput);
                    return Results.Created("api/toolinputs", result);
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
            .WithTags("ToolInput");

        // Update tool input
        app.MapPut("api/toolinputs", async (ToolInputService toolInputService, ToolInputDto toolInput) =>
            {
                try
                {
                    var result = await toolInputService.UpdateToolInput(toolInput);
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
            .WithTags("ToolInput");

        // Delete tool input
        app.MapDelete("api/toolinputs/{id:long}", async (ToolInputService toolInputService, long id) =>
            {
                try
                {
                    var result = await toolInputService.DeleteToolInput(id);
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
            .WithTags("ToolInput");
    }
}