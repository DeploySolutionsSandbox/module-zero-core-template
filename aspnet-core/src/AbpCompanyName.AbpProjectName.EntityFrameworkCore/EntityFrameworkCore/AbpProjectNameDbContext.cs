using Abp.Zero.EntityFrameworkCore;
using AbpCompanyName.AbpProjectName.Authorization.Roles;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using AbpCompanyName.AbpProjectName.MultiTenancy;
using Deploy.LaunchPad.Core.Metadata;
using Deploy.LaunchPad.Util.Elements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Linq;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore;

public class AbpProjectNameDbContext : AbpZeroDbContext<Tenant, Role, User, AbpProjectNameDbContext>
{
    /* Define a DbSet for each entity of the application */

    public AbpProjectNameDbContext(DbContextOptions<AbpProjectNameDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

        foreach (var entityType in entityTypes)
        {
            if (typeof(ILaunchPadMinimalProperties).IsAssignableFrom(entityType.ClrType))
            {
                var nameProperty = entityType.ClrType.GetProperty("Name");
                if (nameProperty == null)
                {
                    modelBuilder.Entity(entityType.ClrType).OwnsOne(
                    typeof(ElementName), "Name",
                    nameBuilder =>
                    {
                        nameBuilder.Property<string>("Short")
                            .HasColumnName("core_name_short")
                            .HasMaxLength(50);

                        nameBuilder.Property<string>("Full")
                            .HasColumnName("core_name_full")
                            .HasMaxLength(255);

                    }
                    );
                }
                var descriptionProperty = entityType.ClrType.GetProperty("Description");
                if (descriptionProperty == null)
                {
                    modelBuilder.Entity(entityType.ClrType).OwnsOne(
                    typeof(ElementDescription), "Description",
                    descriptionBuilder =>
                    {
                        descriptionBuilder.Property<string>("Short")
                            .HasColumnName("core_description_short")
                            .HasMaxLength(255);

                        descriptionBuilder.Property<string>("Full")
                            .HasColumnName("core_description_full")
                        ;
                    }
                    );
                }
            }
        }
    }

}
