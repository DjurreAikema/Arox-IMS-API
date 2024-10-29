using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Services;
using GeneralTools.AspNetCore.MinimalApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AROX.IMS.API.Endpoints;

public class ToolOutputEndpoints : IMapEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        // Get all tool outputs
        app.MapGet("api/tool-outputs", async (ToolOutputService toolOutputService) =>
                Results.Ok((object?) await toolOutputService.GetToolOutputs()))
            .WithTags("ToolOutput");

        // Get tool output by id
        app.MapGet("api/tool-outputs/{id:long}", async (ToolOutputService toolOutputService, long id) =>
            {
                try
                {
                    var toolOutput = await toolOutputService.GetToolOutput(id);
                    return toolOutput == null ? Results.NotFound() : Results.Ok(toolOutput);
                }
                catch (Exception e)
                {
                    return Results.Problem(e.Message);
                }
            })
            .WithTags("ToolOutput");

        // Add new tool output
        app.MapPost("api/tool-outputs", async (ToolOutputService toolOutputService, NewToolOutputDto toolOutput) =>
            {
                try
                {
                    var result = await toolOutputService.AddToolOutput(toolOutput);
                    return Results.Created("api/tool-outputs", result);
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
            .WithTags("ToolOutput");

        // Update tool output
        app.MapPut("api/tool-outputs/{id:long}", async (ToolOutputService toolOutputService, long id, ToolOutputDto toolOutput) =>
            {
                try
                {
                    var result = await toolOutputService.UpdateToolOutput(id, toolOutput);
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
            .WithTags("ToolOutput");

        // Delete tool output
        app.MapDelete("api/tool-outputs/{id:long}", async (ToolOutputService toolOutputService, long id) =>
            {
                try
                {
                    var result = await toolOutputService.DeleteToolOutput(id);
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
            .WithTags("ToolOutput");
    }
}