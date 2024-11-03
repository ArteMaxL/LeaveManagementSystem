namespace LeaveManagementSystem.Web.Common;

public static class Roles
{
    public const string Administrator = nameof(Roles.Administrator);
    public const string Supervisor = nameof(Roles.Supervisor);
    public const string Employee = nameof(Roles.Employee);
}

//public enum Roles
//{
//    Administrator,
//    Supervisor,
//    Employee
//}

//public static class RoleHelper
//{
//    public static string GetRoleString(Roles role)
//    {
//        //return role.ToString();
//        return nameof(role);
//    }
//}
