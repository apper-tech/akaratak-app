using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ApperTech.Akaratak.Configuration.Dto;

namespace ApperTech.Akaratak.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AkaratakAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
