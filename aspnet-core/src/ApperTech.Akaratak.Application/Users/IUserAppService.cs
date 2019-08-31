using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ApperTech.Akaratak.Roles.Dto;
using ApperTech.Akaratak.Users.Dto;

namespace ApperTech.Akaratak.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
