using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes;

public class LeaveTypeEditVM : BaseLeaveTypeVM
{
    [Required]
    [Length(4, 150, ErrorMessage = "Name must between 4 and 150 characters")]
    public required string Name { get; set; }

    [Display(Name = "Days")]
    [Required]
    [Range(1, 90)]
    public int NumberOfDays { get; set; }
}
