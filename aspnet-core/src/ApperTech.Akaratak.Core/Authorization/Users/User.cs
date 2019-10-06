using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using ApperTech.Akaratak.Configuration;
using ApperTech.Akaratak.Realestate;

namespace ApperTech.Akaratak.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public Photo Photo { get; set; }

        public string IdToken { get; set; }

        public UserType UserType { get; set; }

        public string Organization { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string WebsiteUrl { get; set; }

        public string LinkedinUrl { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }

        public User Update(User user)
        {
            return ((User)this.Copy(user));
        }
    }

    public enum UserType
    {
        Agent,
        Agency,
        Buyer,
    }
}
