using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Akaratak.Configuration;
using Akaratak.Web;

namespace Akaratak.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AkaratakDbContextFactory : IDesignTimeDbContextFactory<AkaratakDbContext>
    {
        public AkaratakDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AkaratakDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AkaratakDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AkaratakConsts.ConnectionStringName));

            return new AkaratakDbContext(builder.Options);
        }
    }
}
