using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes;

public abstract class BaseLeaveTypeVM
{
    [Required]
    public Guid Id { get; set; }
}
