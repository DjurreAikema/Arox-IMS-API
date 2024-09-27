using AROX.IMS.API.Classes;
using IMS.EF.Models;

namespace AROX.IMS.API.Helpers;

public class CustomerConverters
{
    // Convert EF model to DTO
    public static CustomerDto ToModel(Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name
        };
    }

    // Convert DTO to EF model
    public static Customer ToEntity(CustomerDto customer)
    {
        return new Customer
        {
            Id = customer.Id,
            Name = customer.Name
        };
    }

    // Update EF model with DTO
    public static void UpdateEntity(Customer customer, CustomerDto customerModel)
    {
        customer.Name = customerModel.Name;
    }
}