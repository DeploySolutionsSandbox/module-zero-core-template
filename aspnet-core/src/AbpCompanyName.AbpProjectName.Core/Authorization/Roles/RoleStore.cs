using Abp.Authorization.Roles;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using Deploy.LaunchPad.Core.Domain.Repositories;
using Deploy.LaunchPad.Core.Domain.UnitOfWork;

namespace AbpCompanyName.AbpProjectName.Authorization.Roles;

public class RoleStore : AbpRoleStore<Role, User>
{
    public RoleStore(
        IUnitOfWorkManager unitOfWorkManager,
        IRepository<Role> roleRepository,
        IRepository<RolePermissionSetting> rolePermissionSettingRepository)
        : base(
            unitOfWorkManager,
            roleRepository,
            rolePermissionSettingRepository)
    {
    }
}
