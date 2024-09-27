using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Helpers;
using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class ToolOutputService(AROX_IMSContext context)
{
    // Get all tool outputs
    public async Task<List<ToolOutputDto>> GetToolOutputs()
    {
        return await context.ToolOutputs
            .Select(x => ToolOutputConverters.ToModel(x))
            .ToListAsync();
    }

    // Get tool output by id
    public async Task<ToolOutputDto?> GetToolOutput(long id)
    {
        return await context.ToolOutputs
            .Where(x => x.Id == id)
            .Select(x => ToolOutputConverters.ToModel(x))
            .FirstOrDefaultAsync();
    }

    // Add new tool output
    public async Task<ToolOutputDto> AddToolOutput(NewToolOutputDto toolOutput)
    {
        // Validate
        await NotFoundException.EnsureToolExists(context, toolOutput.ToolId);
        await NotFoundException.EnsureFieldTypeExists(context, toolOutput.FieldTypeId);

        // Add
        var newToolOutput = ToolOutputConverters.ToEntity(toolOutput);
        context.ToolOutputs.Add(newToolOutput);
        await context.SaveChangesAsync();

        // Return
        return ToolOutputConverters.ToModel(newToolOutput);
    }

    // Update tool output
    public async Task<ToolOutputDto> UpdateToolOutput(ToolOutputDto toolOutput)
    {
        // Validate
        var existingToolOutput = await NotFoundException.EnsureToolOutputExists(context, toolOutput.Id);
        await NotFoundException.EnsureToolExists(context, toolOutput.ToolId);
        await NotFoundException.EnsureFieldTypeExists(context, toolOutput.FieldTypeId);

        // Update
        ToolOutputConverters.UpdateEntity(existingToolOutput, toolOutput);
        context.Entry(existingToolOutput).State = EntityState.Modified;
        await context.SaveChangesAsync();

        // Return
        return ToolOutputConverters.ToModel(existingToolOutput);
    }

    // Delete tool output
    public async Task<ToolOutputDto> DeleteToolOutput(long id)
    {
        // Validate
        var existingToolOutput = await NotFoundException.EnsureToolOutputExists(context, id);

        // Delete
        context.ToolOutputs.Remove(existingToolOutput);
        await context.SaveChangesAsync();

        // Return
        return ToolOutputConverters.ToModel(existingToolOutput);
    }
}