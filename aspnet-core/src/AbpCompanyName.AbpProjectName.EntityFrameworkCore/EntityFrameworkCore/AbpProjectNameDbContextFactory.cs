using AbpCompanyName.AbpProjectName.Configuration;
using AbpCompanyName.AbpProjectName.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore;

/* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
public class AbpProjectNameDbContextFactory : IDesignTimeDbContextFactory<AbpProjectNameDbContext>
{
    public AbpProjectNameDbContext CreateDbContext(string[] args)
    {

        /*
         You can provide an environmentName parameter to the AppConfigurations.Get method. 
         In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
         Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
         https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
         */
        //var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        var basePath = Directory.GetCurrentDirectory();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .AddUserSecrets(typeof(AbpProjectNameDbContext).Assembly, optional: true)
            .AddEnvironmentVariables()
            .Build();

        string connectionString = configuration.GetConnectionString(AbpProjectNameConsts.ConnectionStringName);
        var builder = new DbContextOptionsBuilder<AbpProjectNameDbContext>();
        builder.UseNpgsql(connectionString, x => x.UseNetTopologySuite());

        AbpProjectNameDbContextConfigurer.Configure(builder, connectionString);

        return new AbpProjectNameDbContext(builder.Options);
    }
}
