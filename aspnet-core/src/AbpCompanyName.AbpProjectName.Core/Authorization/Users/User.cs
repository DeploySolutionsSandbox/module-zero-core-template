using Abp.Authorization.Users;
using Deploy.LaunchPad.Util.Extensions;
using System;
using System.Collections.Generic;

namespace AbpCompanyName.AbpProjectName.Authorization.Users;

public class User : AbpUser<User>
{
    public const string DefaultPassword = "123qwe";

    public static string CreateRandomPassword()
    {
        return Guid.NewGuid().ToString("N").Truncate(16);
    }

    public static User CreateTenantAdminUser(System.Guid tenantId, string emailAddress)
    {
        var user = new User
        {
            Id= Guid.NewGuid(),
            TenantId = tenantId,
            UserName = AdminUserName,
            Name = AdminUserName,
            Surname = AdminUserName,
            EmailAddress = emailAddress,
            Roles = new List<UserRole>()
        };

        user.SetNormalizedNames();

        return user;
    }
}
