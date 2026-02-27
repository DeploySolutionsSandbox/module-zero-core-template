using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Runtime.Caching;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using AbpCompanyName.AbpProjectName.MultiTenancy;
using Deploy.LaunchPad.Core.Application.Features;
using Deploy.LaunchPad.Core.Domain.Repositories;
using Deploy.LaunchPad.Core.Domain.UnitOfWork;
using Deploy.LaunchPad.Core.MultiTenancy;
using Deploy.LaunchPad.Core.Runtime.Caching;

namespace AbpCompanyName.AbpProjectName.Features;

public class FeatureValueStore : AbpFeatureValueStore<Tenant, User>
{
    public FeatureValueStore(
        ICacheManager cacheManager,
        IRepository<TenantFeatureSetting> tenantFeatureRepository,
        IRepository<Tenant> tenantRepository,
        IRepository<EditionFeatureSetting> editionFeatureRepository,
        IFeatureManager featureManager,
        IUnitOfWorkManager unitOfWorkManager)
        : base(
              cacheManager,
              tenantFeatureRepository,
              tenantRepository,
              editionFeatureRepository,
              featureManager,
              unitOfWorkManager)
    {
    }
}
