using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Akaratak.Authorization.Roles;
using Akaratak.Authorization.Users;
using Akaratak.MultiTenancy;

namespace Akaratak.EntityFrameworkCore
{
    public class AkaratakDbContext : AbpZeroDbContext<Tenant, Role, User, AkaratakDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AkaratakDbContext(DbContextOptions<AkaratakDbContext> options)
            : base(options)
        {
        }
    }
}
