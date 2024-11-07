using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Data;

public class LeaveAllocation : BaseEntity
{
    public LeaveType? LeaveType { get; set; }
    public Guid LeaveTypeId { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public ApplicationUser? Employee { get; set; }
    public required string EmployeeId { get; set; }

    public Period? Period { get; set; }
    public Guid PeriodId { get; set; }

    public int Days { get; set; }
}
