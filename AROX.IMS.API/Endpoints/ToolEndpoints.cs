using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Services;
using GeneralTools.AspNetCore.MinimalApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AROX.IMS.API.Endpoints;

public class ToolEndpoints : IMapEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        // Get all tools
        app.MapGet("api/tools", async (ToolService toolService) =>
                Results.Ok((object?) await toolService.GetTools()))
            .WithTags("Tool");

        // Get tool by id
        app.MapGet("api/tools/{id:long}", async (ToolService toolService, long id) =>
            {
                try
                {
                    var tool = await toolService.GetTool(id);
                    return tool == null ? Results.NotFound() : Results.Ok(tool);
                }
                catch (Exception e)
                {
                    return Results.Problem(e.Message);
                }
            })
            .WithTags("Tool");

        // Add new tool
        app.MapPost("api/tools", async (ToolService toolService, NewToolDto tool) =>
            {
                try
                {
                    var result = await toolService.AddTool(tool);
                    return Results.Created("api/tools", result);
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
            .WithTags("Tool");

        // Update tool
        app.MapPut("api/tools", async (ToolService toolService, ToolDto tool) =>
            {
                try
                {
                    var result = await toolService.UpdateTool(tool);
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
            .WithTags("Tool");

        // Delete tool
        app.MapDelete("api/tools/{id:long}", async (ToolService toolService, long id) =>
            {
                try
                {
                    var result = await toolService.DeleteTool(id);
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
            .WithTags("Tool");
    }
}