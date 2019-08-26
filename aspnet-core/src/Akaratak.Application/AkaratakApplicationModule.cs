using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Akaratak.Authorization;

namespace Akaratak
{
    [DependsOn(
        typeof(AkaratakCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AkaratakApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AkaratakAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AkaratakApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
