using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Roles.Dto;
using AbpCompanyName.AbpProjectName.Users.Dto;
using Deploy.LaunchPad.Core.Application.Services;
using Deploy.LaunchPad.Core.Application.Services.Dto;
using System;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Users;

public interface IUserAppService : IAsyncCrudAppService<UserDto, Guid, PagedUserResultRequestDto, CreateUserDto, UserDto>
{
    Task DeActivate(EntityDto user);
    Task Activate(EntityDto user);
    Task<ListResultDto<RoleDto>> GetRoles();
    Task ChangeLanguage(ChangeUserLanguageDto input);

    Task<bool> ChangePassword(ChangePasswordDto input);
}
