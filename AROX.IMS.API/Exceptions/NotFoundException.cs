using IMS.EF.Models;

namespace AROX.IMS.API.Exceptions;

public class NotFoundException(string message) : Exception(message)
{
    // Ensure application exists, and return it if it does
    public static async Task<Application> EnsureApplicationExists(AROX_IMSContext context, long applicationId)
    {
        var application = await context.Applications.FindAsync(applicationId);

        if (application == null)
        {
            throw new NotFoundException($"Application with Id {applicationId} not found.");
        }

        return application;
    }

    // Ensure customer exists, and return it if it does
    public static async Task<Customer> EnsureCustomerExists(AROX_IMSContext context, long customerId)
    {
        var customer = await context.Customers.FindAsync(customerId);

        if (customer == null)
        {
            throw new NotFoundException($"Customer with Id {customerId} not found.");
        }

        return customer;
    }

    // Ensure FieldType exists, and return it if it does
    public static async Task<FieldType> EnsureFieldTypeExists(AROX_IMSContext context, long fieldTypeId)
    {
        var fieldType = await context.FieldTypes.FindAsync(fieldTypeId);

        if (fieldType == null)
        {
            throw new NotFoundException($"FieldType with Id {fieldTypeId} not found.");
        }

        return fieldType;
    }

    // Ensure InputOption exists, and return it if it does
    public static async Task<InputOption> EnsureInputOptionExists(AROX_IMSContext context, long inputOptionId)
    {
        var inputOption = await context.InputOptions.FindAsync(inputOptionId);

        if (inputOption == null)
        {
            throw new NotFoundException($"InputOption with Id {inputOptionId} not found.");
        }

        return inputOption;
    }

    // Ensure ToolInput exists, and return it if it does
    public static async Task<ToolInput> EnsureToolInputExists(AROX_IMSContext context, long toolInputId)
    {
        var toolInput = await context.ToolInputs.FindAsync(toolInputId);

        if (toolInput == null)
        {
            throw new NotFoundException($"ToolInput with Id {toolInputId} not found.");
        }

        return toolInput;
    }

    // Ensure ToolOutput exists, and return it if it does
    public static async Task<ToolOutput> EnsureToolOutputExists(AROX_IMSContext context, long toolOutputId)
    {
        var toolOutput = await context.ToolOutputs.FindAsync(toolOutputId);

        if (toolOutput == null)
        {
            throw new NotFoundException($"ToolOutput with Id {toolOutputId} not found.");
        }

        return toolOutput;
    }

    // Ensure Tool exists, and return it if it does
    public static async Task<Tool> EnsureToolExists(AROX_IMSContext context, long toolId)
    {
        var tool = await context.Tools.FindAsync(toolId);

        if (tool == null)
        {
            throw new NotFoundException($"Tool with Id {toolId} not found.");
        }

        return tool;
    }
}