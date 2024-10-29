using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services;

public class LeaveTypesService(ApplicationDbContext context, IMapper mapper) : ILeaveTypesService
{
    public async Task<List<LeaveTypeReadOnlyVM>> GetAllAsync()
    {
        var data = await context.LeaveTypes.ToListAsync();
        return mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
    }

    public async Task<T?> GetAsync<T>(Guid id) where T : class
    {
        var data = await context.LeaveTypes
            .FirstOrDefaultAsync(m => m.Id == id);

        if (data == null)
            return null;

        return mapper.Map<T>(data);
    }

    public async Task RemoveAsync(Guid id)
    {
        var data = await context.LeaveTypes
            .FirstOrDefaultAsync(m => m.Id == id);

        if (data != null)
        {
            context.LeaveTypes.Remove(data);
            await context.SaveChangesAsync();
        }
    }

    public async Task EditAsync(LeaveTypeEditVM model)
    {
        var leaveType = mapper.Map<LeaveType>(model);
        context.Update(leaveType);
        await context.SaveChangesAsync();
    }

    public async Task CreateAsync(LeaveTypeCreateVM model)
    {
        var leaveType = mapper.Map<LeaveType>(model);
        context.Add(leaveType);
        await context.SaveChangesAsync();
    }

    public async Task<bool> LeaveTypeExistsAsync(Guid? id = null, string? name = null)
    {
        return await context.LeaveTypes.AnyAsync(e =>
            (id != null && e.Id == id) ||
            (name != null && e.Name.ToLower() == name.ToLower())
        );
    }

    public async Task<bool> LeaveTypeExistsForEditAsync(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowerCaseName = leaveTypeEdit.Name.ToLower();

        return await context.LeaveTypes.AnyAsync(e =>
            e.Name.ToLower().Equals(lowerCaseName) &&
            e.Id != leaveTypeEdit.Id);
    }
}
