using System.Threading.Tasks;
using Abp.Application.Services;
using ApperTech.Akaratak.Authorization.Accounts.Dto;
using ApperTech.Akaratak.Users.Dto;

namespace ApperTech.Akaratak.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);

        Task<UserDto> GetUserInfo(UserInfoInput input);
    }
}
