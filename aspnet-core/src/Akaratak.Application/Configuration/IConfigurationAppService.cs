using System.Threading.Tasks;
using Akaratak.Configuration.Dto;

namespace Akaratak.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
