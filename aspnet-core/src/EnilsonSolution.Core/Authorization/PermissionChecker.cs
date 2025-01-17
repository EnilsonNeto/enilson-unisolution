using Abp.Authorization;
using EnilsonSolution.Authorization.Roles;
using EnilsonSolution.Authorization.Users;

namespace EnilsonSolution.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
