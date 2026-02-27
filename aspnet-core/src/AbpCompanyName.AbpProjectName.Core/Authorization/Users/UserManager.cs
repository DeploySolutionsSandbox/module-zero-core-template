using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using AbpCompanyName.AbpProjectName.Authorization.Roles;
using Deploy.LaunchPad.Core.Domain.Repositories;
using Deploy.LaunchPad.Core.Domain.UnitOfWork;
using Deploy.LaunchPad.Core.Runtime.Caching;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace AbpCompanyName.AbpProjectName.Authorization.Users;

public class UserManager : AbpUserManager<Role, User>
{
    public UserManager(
      RoleManager roleManager,
      UserStore store,
      IOptions<IdentityOptions> optionsAccessor,
      IPasswordHasher<User> passwordHasher,
      IEnumerable<IUserValidator<User>> userValidators,
      IEnumerable<IPasswordValidator<User>> passwordValidators,
      ILookupNormalizer keyNormalizer,
      IdentityErrorDescriber errors,
      IServiceProvider services,
      ILogger<UserManager<User>> logger,
      IPermissionManager permissionManager,
      IUnitOfWorkManager unitOfWorkManager,
      ICacheManager cacheManager,
      IRepository<OrganizationUnit> organizationUnitRepository,
      IRepository<UserOrganizationUnit> userOrganizationUnitRepository,
      IOrganizationUnitSettings organizationUnitSettings,
      ISettingManager settingManager,
      IRepository<UserLogin> userLoginRepository)
      : base(
          roleManager,
          store,
          optionsAccessor,
          passwordHasher,
          userValidators,
          passwordValidators,
          keyNormalizer,
          errors,
          services,
          logger,
          permissionManager,
          unitOfWorkManager,
          cacheManager,
          organizationUnitRepository,
          userOrganizationUnitRepository,
          organizationUnitSettings,
          settingManager,
          userLoginRepository)
    {
    }
}
