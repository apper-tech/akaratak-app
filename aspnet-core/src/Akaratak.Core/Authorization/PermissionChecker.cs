using Abp.Authorization;
using Akaratak.Authorization.Roles;
using Akaratak.Authorization.Users;

namespace Akaratak.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
