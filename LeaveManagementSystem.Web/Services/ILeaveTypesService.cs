using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services;
public interface ILeaveTypesService
{
    Task CreateAsync(LeaveTypeCreateVM model);
    Task EditAsync(LeaveTypeEditVM model);
    Task<List<LeaveTypeReadOnlyVM>> GetAllAsync();
    Task<T?> GetAsync<T>(Guid id) where T : class;
    Task<bool> LeaveTypeExistsAsync(Guid? id = null, string? name = null);
    Task<bool> LeaveTypeExistsForEditAsync(LeaveTypeEditVM leaveTypeEdit);
    Task RemoveAsync(Guid id);
}