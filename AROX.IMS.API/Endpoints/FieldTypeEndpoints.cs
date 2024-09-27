using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Services;
using GeneralTools.AspNetCore.MinimalApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AROX.IMS.API.Endpoints;

public class FieldTypeEndpoints : IMapEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        // Get all field types
        app.MapGet("api/fieldtypes", async (FieldTypeService fieldTypeService) =>
                Results.Ok((object?) await fieldTypeService.GetFieldTypes()))
            .WithTags("FieldType");

        // Get field type by id
        app.MapGet("api/fieldtypes/{id:long}", async (FieldTypeService fieldTypeService, long id) =>
            {
                try
                {
                    var fieldType = await fieldTypeService.GetFieldType(id);
                    return fieldType == null ? Results.NotFound() : Results.Ok(fieldType);
                }
                catch (Exception e)
                {
                    return Results.Problem(e.Message);
                }
            })
            .WithTags("FieldType");

        // Add new field type
        app.MapPost("api/fieldtypes", async (FieldTypeService fieldTypeService, NewFieldTypeDto fieldType) =>
            {
                try
                {
                    var result = await fieldTypeService.AddFieldType(fieldType);
                    return Results.Created("api/fieldtypes", result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            })
            .WithTags("FieldType");

        // Update field type
        app.MapPut("api/fieldtypes", async (FieldTypeService fieldTypeService, FieldTypeDto fieldType) =>
            {
                try
                {
                    var result = await fieldTypeService.UpdateFieldType(fieldType);
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
            .WithTags("FieldType");

        // Delete field type
        app.MapDelete("api/fieldtypes/{id:long}", async (FieldTypeService fieldTypeService, long id) =>
            {
                try
                {
                    var result = await fieldTypeService.DeleteFieldType(id);
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
            .WithTags("FieldType");
    }
}