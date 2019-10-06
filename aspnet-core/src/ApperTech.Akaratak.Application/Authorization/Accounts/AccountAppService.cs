using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Configuration;
using Abp.ObjectMapping;
using Abp.UI;
using Abp.Zero.Configuration;
using ApperTech.Akaratak.Authorization.Accounts.Dto;
using ApperTech.Akaratak.Authorization.Users;
using ApperTech.Akaratak.Realestate;
using ApperTech.Akaratak.Realestate.Manager;
using ApperTech.Akaratak.Users.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ApperTech.Akaratak.Authorization.Accounts
{
    public class AccountAppService : AkaratakAppServiceBase, IAccountAppService
    {
        // from: http://regexlib.com/REDetails.aspx?regexp_id=1923
        public const string PasswordRegex = "(?=^.{8,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s)[0-9a-zA-Z!@#$%^&*()]*$";

        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly PhotoManager _photoManager;
        public LogInManager InManager { get; }
        private readonly UserManager _userManager;
        private readonly IObjectMapper _objectMapper;

        public AccountAppService(
            UserRegistrationManager userRegistrationManager,
            LogInManager logInManager,
            PhotoManager photoManager,
            UserManager userManager,
            IObjectMapper objectMapper)
        {
            _userRegistrationManager = userRegistrationManager;
            _photoManager = photoManager;
            InManager = logInManager;
            _userManager = userManager;
            _objectMapper = objectMapper;
        }

        public async Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input)
        {
            var tenant = await TenantManager.FindByTenancyNameAsync(input.TenancyName);
            if (tenant == null)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.NotFound);
            }

            if (!tenant.IsActive)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.InActive);
            }

            return new IsTenantAvailableOutput(TenantAvailabilityState.Available, tenant.Id);
        }

        public async Task<RegisterOutput> Register(RegisterInput input)
        {
            var user = await _userRegistrationManager.RegisterAsync(
                input.Name,
                input.Surname,
                input.EmailAddress,
                input.UserName,
                input.Password,
                input.PhoneNumber,
                true, // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
                input.UserType,
                input.PhotoUrl,
                string.Empty
                );

            var isEmailConfirmationRequiredForLogin = await SettingManager
                .GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement
                    .IsEmailConfirmationRequiredForLogin);

            return new RegisterOutput
            {
                CanLogin = user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin)
            };
        }
        [AbpAuthorize()]
        public async Task<UserDto> GetUserInfo()
        {
            return _objectMapper.Map<UserDto>(await GetUser());
        }
        [AbpAuthorize()]
        public async Task<bool> UpdateUser(UpdateUserInput input)
        {
            return (await _userManager
                .UpdateAsync(
                    (await GetUser())
                    .Update(_objectMapper.Map<User>(input))
                )).Succeeded;
        }

        [AbpAuthorize()]
        public async Task<bool> UpdatePhotoForUser(string photoUrl, IFormFile file)
        {
            var user = await GetUser();

            user.Photo = !string.IsNullOrEmpty(photoUrl)
                ? new Photo
                {
                    Url = photoUrl,
                    PublicId = Guid.NewGuid().ToString(),
                    IsMain = true
                }
                : (await this._photoManager.UploadPhoto(file));

            return (await _userManager.UpdateAsync(user)).Succeeded;

        }


        private async Task<User> GetUser()
        {
            //if (!string.IsNullOrEmpty(input.IdToken))
            //    user = await _userManager.Users.Where(x => x.IdToken == input.IdToken).FirstOrDefaultAsync();
            if (AbpSession.UserId != null)
                return await _userManager.Users
                    .Where(x => x.Id == AbpSession.UserId)
                    .Include(c => c.Photo)
                    .FirstOrDefaultAsync();
            else
                throw new UserFriendlyException("user not logged in");
        }
    }
}
