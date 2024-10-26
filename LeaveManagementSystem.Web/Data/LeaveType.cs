using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Data;

public class LeaveType
{
    public Guid Id { get; set; }

    [MaxLength(150)]
    public required string Name { get; set; }
    public int NumberOfDays { get; set; }
}
