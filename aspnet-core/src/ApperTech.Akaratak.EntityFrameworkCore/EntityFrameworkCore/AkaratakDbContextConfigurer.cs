using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ApperTech.Akaratak.EntityFrameworkCore
{
    public static class AkaratakDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AkaratakDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AkaratakDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
