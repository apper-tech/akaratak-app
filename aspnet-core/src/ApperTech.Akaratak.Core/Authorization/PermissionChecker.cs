using Abp.Authorization;
using ApperTech.Akaratak.Authorization.Roles;
using ApperTech.Akaratak.Authorization.Users;

namespace ApperTech.Akaratak.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
