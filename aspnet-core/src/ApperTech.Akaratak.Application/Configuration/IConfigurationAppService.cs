using System.Threading.Tasks;
using ApperTech.Akaratak.Configuration.Dto;

namespace ApperTech.Akaratak.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
