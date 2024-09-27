using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Helpers;
using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class ToolService(AROX_IMSContext context)
{
    // Get all tools
    public async Task<List<ToolDto>> GetTools()
    {
        return await context.Tools
            .Select(x => ToolConverters.ToModel(x))
            .ToListAsync();
    }

    // Get tool by id
    public async Task<ToolDto?> GetTool(long id)
    {
        return await context.Tools
            .Where(x => x.Id == id)
            .Select(x => ToolConverters.ToModel(x))
            .FirstOrDefaultAsync();
    }

    // Add new tool
    public async Task<ToolDto> AddTool(NewToolDto tool)
    {
        // Validate
        await NotFoundException.EnsureApplicationExists(context, tool.ApplicationId);

        // Add
        var newTool = ToolConverters.ToEntity(tool);
        context.Tools.Add(newTool);
        await context.SaveChangesAsync();

        // Return
        return ToolConverters.ToModel(newTool);
    }

    // Update tool
    public async Task<ToolDto> UpdateTool(ToolDto tool)
    {
        // Validate
        var existingTool = await NotFoundException.EnsureToolExists(context, tool.Id);
        await NotFoundException.EnsureApplicationExists(context, tool.ApplicationId);

        // Update
        ToolConverters.UpdateEntity(existingTool, tool);
        context.Entry(existingTool).State = EntityState.Modified;
        await context.SaveChangesAsync();

        // Return
        return ToolConverters.ToModel(existingTool);
    }

    // Delete tool
    public async Task<ToolDto> DeleteTool(long id)
    {
        // Validate
        var existingTool = await NotFoundException.EnsureToolExists(context, id);

        // Delete
        context.Tools.Remove(existingTool);
        await context.SaveChangesAsync();

        // Return
        return ToolConverters.ToModel(existingTool);
    }
}