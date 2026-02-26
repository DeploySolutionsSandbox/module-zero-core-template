using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed.Host;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed.Tenants;
using Deploy.LaunchPad.Core.Domain.UnitOfWork;
using Deploy.LaunchPad.Core.MultiTenancy;
using Deploy.LaunchPad.Util.Dependency;
using Deploy.LaunchPad.Util.Guids;
using Microsoft.EntityFrameworkCore;
using System;
using System.Transactions;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed;

public static class SeedHelper
{
    public static void SeedHostDb(IIocResolver iocResolver)
    {
        WithDbContext<AbpProjectNameDbContext>(iocResolver, SeedHostDb);
    }

    public static void SeedHostDb(AbpProjectNameDbContext context)
    {
        context.SuppressAutoSetTenantId = true;

        // Host seed
        new InitialHostDbBuilder(context).Create();

        // Default tenant seed (in host database).
        new DefaultTenantBuilder(context).Create();
        new TenantRoleAndUserBuilder(context, GuidConstants.Default).Create();
    }

    private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
        where TDbContext : DbContext
    {
        using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
        {
            using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
            {
                var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                contextAction(context);

                uow.Complete();
            }
        }
    }
}
