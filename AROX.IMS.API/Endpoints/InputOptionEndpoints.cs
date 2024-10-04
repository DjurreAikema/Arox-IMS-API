using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Services;
using GeneralTools.AspNetCore.MinimalApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AROX.IMS.API.Endpoints;

public class InputOptionEndpoints : IMapEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        // Get all input options
        app.MapGet("api/input-options", async (InputOptionService inputOptionService) =>
                Results.Ok((object?) await inputOptionService.GetInputOptions()))
            .WithTags("InputOption");

        // Get input option by id
        app.MapGet("api/input-options/{id:long}", async (InputOptionService inputOptionService, long id) =>
            {
                try
                {
                    var inputOption = await inputOptionService.GetInputOption(id);
                    return inputOption == null ? Results.NotFound() : Results.Ok(inputOption);
                }
                catch (Exception e)
                {
                    return Results.Problem(e.Message);
                }
            })
            .WithTags("InputOption");

        // Add new input option
        app.MapPost("api/input-options", async (InputOptionService inputOptionService, NewInputOptionDto inputOption) =>
            {
                try
                {
                    var result = await inputOptionService.AddInputOption(inputOption);
                    return Results.Created("api/input-options", result);
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
            .WithTags("InputOption");

        // Update input option
        app.MapPut("api/input-options/{id:long}", async (InputOptionService inputOptionService, long id, InputOptionDto inputOption) =>
            {
                try
                {
                    var result = await inputOptionService.UpdateInputOption(id, inputOption);
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
            .WithTags("InputOption");

        // Delete input option
        app.MapDelete("api/input-options/{id:long}", async (InputOptionService inputOptionService, long id) =>
            {
                try
                {
                    var result = await inputOptionService.DeleteInputOption(id);
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
            .WithTags("InputOption");
    }
}