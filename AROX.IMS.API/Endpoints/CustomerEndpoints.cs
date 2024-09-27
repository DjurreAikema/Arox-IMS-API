using AROX.IMS.API.Classes;
using AROX.IMS.API.Services;
using GeneralTools.AspNetCore.MinimalApi;
using IMS.EF.Models;
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
            Results.Ok((object?) await customerService.GetCustomers()));

        // Get customer by id
        app.MapGet("api/customers/{id:long}", async (CustomerService customerService, long id) =>
        {
            var customer = await customerService.GetCustomer(id);
            return customer == null ? Results.NotFound() : Results.Ok(customer);
        });

        // Add new customer
        app.MapPost("api/customers", async (CustomerService customerService, Customer customer) =>
            Results.Created("api/customers", await customerService.AddCustomer(customer)));

        // Update customer
        app.MapPut("api/customers", async (CustomerService customerService, Customer customer) =>
            Results.Ok((object?) await customerService.UpdateCustomer(customer)));

        // Delete customer
        app.MapDelete("api/customers/{id:long}", async (CustomerService customerService, long id) =>
            Results.Ok((object?) await customerService.DeleteCustomer(id)));
    }
}