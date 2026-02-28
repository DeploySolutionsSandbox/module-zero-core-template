using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore;

public static class AbpProjectNameDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<AbpProjectNameDbContext> builder, string connectionString)
    {
        //builder.UseSqlServer(connectionString);
        // Enable NetTopologySuite for spatial data support
        builder.UseNpgsql(connectionString, options => options.UseNetTopologySuite());

    }

    public static void Configure(DbContextOptionsBuilder<AbpProjectNameDbContext> builder, DbConnection connection)
    {
        //builder.UseSqlServer(connection);
        // Enable NetTopologySuite for spatial data support
        builder.UseNpgsql(connection, options => options.UseNetTopologySuite());

    }
}
