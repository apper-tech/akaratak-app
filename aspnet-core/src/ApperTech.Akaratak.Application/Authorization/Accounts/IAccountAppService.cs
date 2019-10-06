using System.Threading.Tasks;
using Abp.Application.Services;
using ApperTech.Akaratak.Authorization.Accounts.Dto;
using ApperTech.Akaratak.Authorization.Users;
using ApperTech.Akaratak.Users.Dto;
using Microsoft.AspNetCore.Http;

namespace ApperTech.Akaratak.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);

        Task<UserDto> GetUserInfo();

        Task<bool> UpdateUser(UpdateUserInput input);

        Task<bool> UpdatePhotoForUser(string photoUrl, IFormFile file);
    }
}
