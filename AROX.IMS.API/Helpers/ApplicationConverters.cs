using AROX.IMS.API.Classes;
using IMS.EF.Models;

namespace AROX.IMS.API.Helpers;

public class ApplicationConverters
{
    // Convert EF model to DTO
    public static ApplicationDto ToModel(Application application)
    {
        return new ApplicationDto
        {
            Id = application.Id,
            CustomerId = application.CustomerId,
            Name = application.Name
        };
    }

    // Convert DTO to EF model
    public static Application ToEntity(ApplicationDto application)
    {
        return new Application
        {
            Id = application.Id,
            CustomerId = application.CustomerId,
            Name = application.Name
        };
    }

    // Update EF model with DTO
    public static void UpdateEntity(Application application, ApplicationDto applicationModel)
    {
        application.CustomerId = applicationModel.CustomerId;
        application.Name = applicationModel.Name;
    }
}