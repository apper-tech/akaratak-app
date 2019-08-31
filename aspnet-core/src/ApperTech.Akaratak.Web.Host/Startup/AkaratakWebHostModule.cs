using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ApperTech.Akaratak.Configuration;

namespace ApperTech.Akaratak.Web.Host.Startup
{
    [DependsOn(
       typeof(AkaratakWebCoreModule))]
    public class AkaratakWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AkaratakWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AkaratakWebHostModule).GetAssembly());
        }
    }
}
