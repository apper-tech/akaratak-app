using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ApperTech.Akaratak.Configuration;
using ApperTech.Akaratak.Web;

namespace ApperTech.Akaratak.EntityFrameworkCore
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
