using System.Threading.Tasks;
using Abp.Application.Services;
using ApperTech.Akaratak.Authorization.Accounts.Dto;

namespace ApperTech.Akaratak.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);

        Task<LogInOutput> LogIn(LogInInput input);
    }
}
