using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using AbpCompanyName.AbpProjectName.Authorization.Roles;
using Deploy.LaunchPad.Core.Domain.Repositories;
using Deploy.LaunchPad.Core.Domain.UnitOfWork;

namespace AbpCompanyName.AbpProjectName.Authorization.Users;

public class UserStore : AbpUserStore<Role, User>
{
    public UserStore(
        IUnitOfWorkManager unitOfWorkManager,
        IRepository<User> userRepository,
        IRepository<Role> roleRepository,
        IRepository<UserRole> userRoleRepository,
        IRepository<UserLogin> userLoginRepository,
        IRepository<UserClaim> userClaimRepository,
        IRepository<UserPermissionSetting> userPermissionSettingRepository,
        IRepository<UserOrganizationUnit> userOrganizationUnitRepository,
        IRepository<OrganizationUnitRole> organizationUnitRoleRepository,
        IRepository<UserToken> userTokenRepository
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
