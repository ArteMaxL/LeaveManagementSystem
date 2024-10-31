using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole 
            {
                Id = "8efad8c1-bd44-485d-a9a5-302fe64a485e",
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
            }, 
            new IdentityRole 
            {
                Id = "472e7cb5-daff-46e1-b1c3-7b4e4b9b9286",
                Name = "Supervisor",
                NormalizedName = "SUPERVISOR",
            },
            new IdentityRole 
            {
                Id = "0af56abf-77c1-49f0-bbb0-1cf91f842414",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
            });

        var hasher = new PasswordHasher<IdentityUser>();
        var adminUserEmail = "admin@localhost.com";

        builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "b8cb80f3-f899-44b9-9224-0de58b20335b",
                Email = adminUserEmail,
                UserName = adminUserEmail,
                NormalizedEmail = adminUserEmail.ToUpper(),
                NormalizedUserName = adminUserEmail.ToUpper(),
                PasswordHash = hasher.HashPassword(null!, "P@sswOrd001"),
                EmailConfirmed = true,
            });

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "0af56abf-77c1-49f0-bbb0-1cf91f842414",
                UserId = "b8cb80f3-f899-44b9-9224-0de58b20335b"
            });
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
}
