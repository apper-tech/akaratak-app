using System.Threading.Tasks;
using Abp.Application.Services;
using Akaratak.Authorization.Accounts.Dto;

namespace Akaratak.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
