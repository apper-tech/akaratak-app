using System.Security.Claims;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using ApperTech.Akaratak.Authorization.Users;
using ApperTech.Akaratak.Users.Dto;

namespace ApperTech.Akaratak.Authorization.Accounts.Dto
{
    [AutoMapFrom(typeof(AbpLoginResult<MultiTenancy.Tenant, User>))]
    public class LogInOutput
    {
        public AbpLoginResultType Result { get; set; }

       // public MultiTenancy.Tenant Tenant { get; set; }

        public UserDto User { get; set; }
    }
}