using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Roles.Dto;
using Deploy.LaunchPad.Core.Application.Services;
using Deploy.LaunchPad.Core.Application.Services.Dto;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Roles;

public interface IRoleAppService : IAsyncCrudAppService<RoleDto, System.Guid, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>
{
    Task<ListResultDto<PermissionDto>> GetAllPermissions();

    Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

    Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);
}
