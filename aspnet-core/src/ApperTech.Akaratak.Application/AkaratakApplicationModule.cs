using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ApperTech.Akaratak.Authorization;
using ApperTech.Akaratak.Realestate;
using ApperTech.Akaratak.Realestate.Dto;

namespace ApperTech.Akaratak
{
    [DependsOn(
        typeof(AkaratakCoreModule),
        typeof(AbpAutoMapperModule))]
    public class AkaratakApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AkaratakAuthorizationProvider>();
            Configuration.MultiTenancy.IsEnabled = false;
            Configuration.MultiTenancy.IgnoreFeatureCheckForHostUsers = true;
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AkaratakApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg =>
                {
                    cfg.AddMaps(thisAssembly);
                    cfg.AddProfile(new RealestateMapProfile());
                });
        }
    }
}
