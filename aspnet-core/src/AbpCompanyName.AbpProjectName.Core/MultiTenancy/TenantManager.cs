using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using AbpCompanyName.AbpProjectName.Editions;
using Deploy.LaunchPad.Core.Domain.Repositories;
using Deploy.LaunchPad.Core.MultiTenancy;

namespace AbpCompanyName.AbpProjectName.MultiTenancy;

public class TenantManager : AbpTenantManager<Tenant, User>
{
    public TenantManager(
        IRepository<Tenant> tenantRepository,
        IRepository<TenantFeatureSetting> tenantFeatureRepository,
        EditionManager editionManager,
        IAbpZeroFeatureValueStore featureValueStore)
        : base(
            tenantRepository,
            tenantFeatureRepository,
            editionManager,
            featureValueStore)
    {
    }
}
