using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using AbpCompanyName.AbpProjectName.Authorization.Roles;
using Deploy.LaunchPad.Core.Domain.Repositories;
using Deploy.LaunchPad.Core.Domain.UnitOfWork;
using System;

namespace AbpCompanyName.AbpProjectName.Authorization.Users;

public class UserStore : AbpUserStore<Role, User>
{
    public UserStore(
        IUnitOfWorkManager unitOfWorkManager,
        IRepository<User, Guid> userRepository,
        IRepository<Role, Guid> roleRepository,
        IRepository<UserRole, Guid> userRoleRepository,
        IRepository<UserLogin, Guid> userLoginRepository,
        IRepository<UserClaim, Guid> userClaimRepository,
        IRepository<UserPermissionSetting, Guid> userPermissionSettingRepository,
        IRepository<UserOrganizationUnit, Guid> userOrganizationUnitRepository,
        IRepository<OrganizationUnitRole, Guid> organizationUnitRoleRepository,
        IRepository<UserToken, Guid> userTokenRepository
    )
        : base(unitOfWorkManager,
              userRepository,
              roleRepository,
              userRoleRepository,
              userLoginRepository,
              userClaimRepository,
              userPermissionSettingRepository,
              userOrganizationUnitRepository,
              organizationUnitRoleRepository,
              userTokenRepository
        )
    {
    }
}
