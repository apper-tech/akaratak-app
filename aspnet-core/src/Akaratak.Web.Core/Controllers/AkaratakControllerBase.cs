using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Akaratak.Controllers
{
    public abstract class AkaratakControllerBase: AbpController
    {
        protected AkaratakControllerBase()
        {
            LocalizationSourceName = AkaratakConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
