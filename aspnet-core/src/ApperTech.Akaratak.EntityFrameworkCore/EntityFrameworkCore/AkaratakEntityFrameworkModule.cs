using Abp.EntityFrameworkCore.Configuration;

using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using ApperTech.Akaratak.EntityFrameworkCore.Seed;

namespace ApperTech.Akaratak.EntityFrameworkCore
{
    [DependsOn(
        typeof(AkaratakCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class AkaratakEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<AkaratakDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        AkaratakDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        AkaratakDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AkaratakEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
