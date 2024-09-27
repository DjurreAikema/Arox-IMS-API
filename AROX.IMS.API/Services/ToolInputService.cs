using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Helpers;
using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class ToolInputService(AROX_IMSContext context)
{
    // Get all tool inputs
    public async Task<List<ToolInputDto>> GetToolInputs()
    {
        return await context.ToolInputs
            .Select(x => ToolInputConverters.ToModel(x))
            .ToListAsync();
    }

    // Get tool input by id
    public async Task<ToolInputDto?> GetToolInput(long id)
    {
        return await context.ToolInputs
            .Where(x => x.Id == id)
            .Select(x => ToolInputConverters.ToModel(x))
            .FirstOrDefaultAsync();
    }

    // Add new tool input
    public async Task<ToolInputDto> AddToolInput(NewToolInputDto toolInput)
    {
        // Validate
        await NotFoundException.EnsureToolExists(context, toolInput.ToolId);
        await NotFoundException.EnsureFieldTypeExists(context, toolInput.FieldTypeId);

        // Add
        var newToolInput = ToolInputConverters.ToEntity(toolInput);
        context.ToolInputs.Add(newToolInput);
        await context.SaveChangesAsync();

        // Return
        return ToolInputConverters.ToModel(newToolInput);
    }

    // Update tool input
    public async Task<ToolInputDto> UpdateToolInput(ToolInputDto toolInput)
    {
        // Validate
        var existingToolInput = await NotFoundException.EnsureToolInputExists(context, toolInput.Id);
        await NotFoundException.EnsureToolExists(context, toolInput.ToolId);
        await NotFoundException.EnsureFieldTypeExists(context, toolInput.FieldTypeId);

        // Update
        ToolInputConverters.UpdateEntity(existingToolInput, toolInput);
        context.Entry(existingToolInput).State = EntityState.Modified;
        await context.SaveChangesAsync();

        // Return
        return ToolInputConverters.ToModel(existingToolInput);
    }

    // Delete tool input
    public async Task<ToolInputDto> DeleteToolInput(long id)
    {
        // Validate
        var existingToolInput = await NotFoundException.EnsureToolInputExists(context, id);

        // Delete
        context.ToolInputs.Remove(existingToolInput);
        await context.SaveChangesAsync();

        // Return
        return ToolInputConverters.ToModel(existingToolInput);
    }
}