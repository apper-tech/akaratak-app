using Abp.MultiTenancy;
using ApperTech.Akaratak.Authorization.Users;

namespace ApperTech.Akaratak.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
