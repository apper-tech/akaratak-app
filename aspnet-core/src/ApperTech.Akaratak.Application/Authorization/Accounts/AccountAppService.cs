using System.Threading.Tasks;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.ObjectMapping;
using Abp.Zero.Configuration;
using ApperTech.Akaratak.Authorization.Accounts.Dto;
using ApperTech.Akaratak.Authorization.Users;
using Microsoft.AspNetCore.Identity;

namespace ApperTech.Akaratak.Authorization.Accounts
{
    public class AccountAppService : AkaratakAppServiceBase, IAccountAppService
    {
        // from: http://regexlib.com/REDetails.aspx?regexp_id=1923
        public const string PasswordRegex = "(?=^.{8,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s)[0-9a-zA-Z!@#$%^&*()]*$";

        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly LogInManager _logInManager;
        private readonly IObjectMapper _objectMapper;

        public AccountAppService(
            UserRegistrationManager userRegistrationManager,
            LogInManager logInManager,
            IObjectMapper objectMapper)
        {
            _userRegistrationManager = userRegistrationManager;
            _logInManager = logInManager;
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
                true // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
            );

            var isEmailConfirmationRequiredForLogin = await SettingManager
                .GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement
                    .IsEmailConfirmationRequiredForLogin);

            return new RegisterOutput
            {
                CanLogin = user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin)
            };
        }

        public async Task<LogInOutput> LogIn(LogInInput input)
        {
            return _objectMapper.Map<LogInOutput>(
                await _logInManager.LoginAsync(input.UsernameOrEmailAddress,
                        input.Password, "Default", false));
        }
    }
}
