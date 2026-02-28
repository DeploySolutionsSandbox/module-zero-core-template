using Abp.Authorization.Roles;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AbpCompanyName.AbpProjectName.Authorization.Roles;

public class Role : AbpRole<User>
{
    public const int MaxDescriptionLength = 5000;
    
    [SetsRequiredMembers]
    public Role() :base()
    {
    }

    public Role(System.Guid? tenantId, string displayName)
        : base(tenantId, displayName)
    {
    }

    public Role(System.Guid? tenantId, string name, string displayName)
        : base(tenantId, name, displayName)
    {
    }

}
