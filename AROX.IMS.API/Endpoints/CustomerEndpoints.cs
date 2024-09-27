using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Services;
using GeneralTools.AspNetCore.MinimalApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AROX.IMS.API.Endpoints;

public class CustomerEndpoints : IMapEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        // Get all customers
        app.MapGet("api/customers", async (CustomerService customerService) =>
                Results.Ok((object?) await customerService.GetCustomers()))
            .WithTags("Customer");

        // Get customer by id
        app.MapGet("api/customers/{id:long}", async (CustomerService customerService, long id) =>
            {
                try
                {
                    var customer = await customerService.GetCustomer(id);
                    return customer == null ? Results.NotFound() : Results.Ok(customer);
                }
                catch (Exception e)
                {
                    return Results.Problem(e.Message);
                }
            })
            .WithTags("Customer");

        // Add new customer
        app.MapPost("api/customers", async (CustomerService customerService, NewCustomerDto customer) =>
            {
                try
                {
                    var result = await customerService.AddCustomer(customer);
                    return Results.Created("api/customers", result);
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
            .WithTags("Customer");

        // Update customer
        app.MapPut("api/customers", async (CustomerService customerService, CustomerDto customer) =>
            {
                try
                {
                    var result = await customerService.UpdateCustomer(customer);
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
            .WithTags("Customer");

        // Delete customer
        app.MapDelete("api/customers/{id:long}", async (CustomerService customerService, long id) =>
            {
                try
                {
                    var result = await customerService.DeleteCustomer(id);
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
            .WithTags("Customer");
    }
}