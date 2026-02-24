using Abp.MultiTenancy;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using Deploy.LaunchPad.Core.MultiTenancy;

namespace AbpCompanyName.AbpProjectName.MultiTenancy;

public class Tenant : AbpTenant<User>
{
    public Tenant()
    {
    }

    public Tenant(string tenancyName, string name)
        : base(tenancyName, name)
    {
    }
}
