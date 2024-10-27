using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes;

public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
{
    public required string Name { get; set; }

    [Display(Name ="Days")]
    public int NumberOfDays { get; set; }
}
